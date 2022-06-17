using Microsoft.JSInterop;
using Token.Inject.tag;

namespace HelperApp.Applications.AppService;

public class HelperService : IScopedTag
{
    private readonly IJSRuntime _js;
    public HelperService(IJSRuntime js)
    {
        this._js = js;
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
}
