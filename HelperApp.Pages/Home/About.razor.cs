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
    [Inject] private AppVersionService _appVersionService { get; set; }

    [Inject] private IPopupService _popupService { get; set; }
    public async Task AppVersionAsync()
    {
        var version = await _appVersionService.GetAppVersionAsync();
        if(version.Version != Constant.Version)
        {
            await _popupService.ToastAsync("当前版本不是最新版本，请更新版本", AlertTypes.Error);
        }
    }
}
