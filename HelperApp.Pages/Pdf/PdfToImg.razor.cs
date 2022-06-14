using BlazorComponent;
using HelperApp.Applications.AppService;
using Masa.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Token.HttpClientHelper;

namespace HelperApp.Pages.Pdf;

partial class PdfToImg
{

    [Inject] PdfServices PdfServices { get; set; }
    [Inject] private IPopupService PopupService { get; set; }


    private List<IBrowserFile> _files = new();

    private async Task MangePdfAsync()
    {
        await PopupService.ToastAsync("开始转换", AlertTypes.Info);

        var uploading = _files
        .Select(x => new UploadingDto
        {
            Name = "files",
            FileName = x.Name,
            Stream = x.OpenReadStream(x.Size)
        }).ToList();

        await PdfServices.PdfToImgAsync(uploading);

        await PopupService.ToastAsync("转换完成", AlertTypes.Info);

    }
}
