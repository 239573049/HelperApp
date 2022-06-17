using System.Net;
using Token.HttpClientHelper;
using Token.Inject.tag;

namespace HelperApp.Applications.AppService;

public class PdfServices : IScopedTag
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
        var stream = await _http.UploadingResponseAsync("api/pdf/mange-pdf", uploadings);
        if(stream.StatusCode == HttpStatusCode.OK)
        {
            await _helperService.SaveFileAsync((await stream.Content.ReadAsStreamAsync()), $"{DateTime.Now:yyyyMMddHHmmss}.pdf");
        }
    }

    /// <summary>
    /// 图片转Pdf
    /// </summary>
    /// <param name="uploadings"></param>
    /// <returns></returns>
    public async Task ImgToPdfAsync(List<UploadingDto> uploadings)
    {
        var stream = await _http.UploadingResponseAsync("api/pdf/img-to-pdf", uploadings);

        if(stream.StatusCode == HttpStatusCode.OK)
        {

            await _helperService.SaveFileAsync((await stream.Content.ReadAsStreamAsync()), $"{DateTime.Now:yyyyMMddHHmmss}.pdf");
        }
    }

    /// <summary>
    /// Pdf转换图片
    /// </summary>
    /// <param name="uploadings"></param>
    /// <returns></returns>
    public async Task PdfToImgAsync(List<UploadingDto> uploadings)
    {
        var stream = await _http.UploadingResponseAsync("api/pdf/pdf-to-img", uploadings);

        if(stream.StatusCode == HttpStatusCode.OK)
        {
            await _helperService.SaveFileAsync((await stream.Content.ReadAsStreamAsync()), $"{DateTime.Now:yyyyMMddHHmmss}.zip");
        }
    }
}
