using HelperApp.Applications.AppService;
using HelperApp.Domain;
using Masa.Blazor;
using Microsoft.AspNetCore.Components;

namespace HelperApp.Pages.Components;

partial class UpdateTheInterface
{
    /// <summary>
    /// 是否显示更新弹框
    /// </summary>
    [Parameter]
    public bool UpdateShow { get; set; } = false;

    /// <summary>
    /// 获取的版本信息
    /// </summary>
    [Parameter]
    public AppVersion? appVersion { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Inject] private HelperService _helperService { get; set; }


    [Inject] private IPopupService _popupService { get; set; }

    /// <summary>
    /// 显示下载进度条
    /// </summary>
    private bool ShowDownload { get; set; } = false;

    /// <summary>
    /// 当前下载百分百
    /// </summary>
    private double CurrentDownloadSize { get; set; } = 0;
    private async Task UpdateAsync()
    {
        if(appVersion?.Version != Constant.Version)
        {
            ShowDownload = true;
            await _helperService.UpdateAsync(appVersion?.Download, async (i) =>
            {
                CurrentDownloadSize = (int) await i;
                if(CurrentDownloadSize == 100)
                {
                    ShowDownload = false;
                }
                await _popupService.AlertAsync("更新包已下载至文档目录请前往安装");
                StateHasChanged();
            });
        }

    }
}
