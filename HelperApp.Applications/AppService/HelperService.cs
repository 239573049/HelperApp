using Microsoft.JSInterop;
using Token.HttpClientHelper;
using Token.Inject.tag;

namespace HelperApp.Applications.AppService;

public class HelperService : IScopedTag
{
    private readonly IJSRuntime _js;
    private readonly TokenHttp _tokenHttp;
    public HelperService(IJSRuntime js, TokenHttp tokenHttp)
    {
        this._js = js;
        this._tokenHttp = tokenHttp;
    }

    public string GetPath()
    {
        string path = string.Empty;

#if ANDROID
        path=Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).Path,"helper");

#elif WINDOWS
        path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "helper");
#endif
        if(!Directory.Exists(path))
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch(Exception)
            {
                throw new Exception("创建存储目录失败");
            }
        }

        return path;
    }

    /// <summary>
    /// 保存文件
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public async Task SaveFileAsync(Stream stream, string fileName)
    {

#if(ANDROID || WINDOWS || IOS || MACCATALYST)
        // 获取存放路径
        string path = GetPath();

        var file = File.Create(Path.Combine(path, fileName));
        await stream.CopyToAsync(file);
        stream.Close();
        file.Close();
#else

        using var streamRef = new DotNetStreamReference(stream: stream);
        await _js.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);

#endif

    }

    /// <summary>
    /// 更新下载
    /// </summary>
    /// <returns></returns>
    public async Task UpdateAsync(string url, Action<Task<decimal>> action)
    {
        var message = await _tokenHttp.HttpClient.GetAsync(url);
        // 获取文件大小
        var filesize = message.Content.Headers.ContentLength;
        var stream = await message.Content.ReadAsStreamAsync();
        var file = File.Create(Path.Combine(GetPath(), "helper.apk"));
        var btyes = new byte[4096];
        var readlen = 0;
        int len;
        while((len = await stream.ReadAsync(btyes)) != 0)
        {
            readlen += len;
            var size = (((decimal) readlen / (decimal) filesize) * 100m);
            action?.Invoke(Task.FromResult(size));
            file.Write(btyes);
        }
        stream.Close();
        file.Close();
    }

}
