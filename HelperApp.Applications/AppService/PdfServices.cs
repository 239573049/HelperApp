using Token.HttpClientHelper;
using Token.Inject.tag;

namespace HelperApp.Applications.AppService;

public class PdfServices : ISingletonTag
{
    private readonly TokenHttp _http;
    private readonly HelperService _helperService;
    public PdfServices(TokenHttp http, HelperService helperService)
    {
        _http = http;
        this._helperService = helperService;
    }

    /// <summary>
    /// 合并pdf
    /// </summary>
    /// <param name="uploadings"></param>
    /// <returns></returns>
    public async Task MangePdfAsync(List<UploadingDto> uploadings)
    {
        var stream = await _http.UploadingStreamAsync("api/pdf/mange-pdf", uploadings);

        // 获取存放路径
        string path = _helperService.GetPath();

        var file = File.Create(Path.Combine(path, $"{Guid.NewGuid():N}.pdf"));
        await stream.CopyToAsync(file);
        stream.Close();
        file.Close();
    }

    /// <summary>
    /// 图片转Pdf
    /// </summary>
    /// <param name="uploadings"></param>
    /// <returns></returns>
    public async Task ImgToPdfAsync(List<UploadingDto> uploadings)
    {
        var stream = await _http.UploadingStreamAsync("api/pdf/img-to-pdf", uploadings);


        // 获取存放路径
        string path = _helperService.GetPath();

        var file = File.Create(Path.Combine(path, $"{Guid.NewGuid():N}.pdf"));
        await stream.CopyToAsync(file);
        stream.Close();
        file.Close();
    }
}
