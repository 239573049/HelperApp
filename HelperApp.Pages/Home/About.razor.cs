using BlazorComponent;
using HelperApp.Applications.AppService;
using HelperApp.Domain;
using Masa.Blazor;
using Microsoft.AspNetCore.Components;

namespace HelperApp.Pages.Home;

partial class About
{
    private readonly string Name = Constant.Name;
    private readonly string Version = Constant.Version;

    /// <summary>
    /// 是否显示更新弹框
    /// </summary>
    private bool UpdateShow = false;
    [Inject] private AppVersionService _appVersionService { get; set; }

    [Inject] private IPopupService _popupService { get; set; }

    /// <summary>
    /// 获取的版本信息
    /// </summary>
    private AppVersion? appVersion;

    public async Task AppVersionAsync()
    {
        appVersion = await _appVersionService.GetAppVersionAsync();
        if(appVersion.Version != Constant.Version)
        {
            await _popupService.ToastAsync("当前版本不是最新版本，请更新版本", AlertTypes.Error);
            UpdateShow = true;
        }
    }
}
