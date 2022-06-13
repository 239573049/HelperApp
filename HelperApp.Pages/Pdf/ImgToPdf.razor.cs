using BlazorComponent;
using HelperApp.Applications.AppService;
using Masa.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Token.HttpClientHelper;

namespace HelperApp.Pages.Pdf;

partial class ImgToPdf
{
    [Inject] PdfServices PdfServices { get; set; }

    [Inject] private IPopupService PopupService { get; set; }

    private List<IBrowserFile> _files = new();

    private async Task ImgToPdfAsync()
    {
        await PopupService.ToastAsync("开始合并", AlertTypes.Info);

        var uploading = _files
        .Select(x => new UploadingDto
        {
            Name = "files",
            FileName = x.Name,
            Stream = x.OpenReadStream(x.Size)
        }).ToList();

        await PdfServices.ImgToPdfAsync(uploading);


        await PopupService.ToastAsync("合并完成，请检查文档目录", AlertTypes.Info);

    }


}
