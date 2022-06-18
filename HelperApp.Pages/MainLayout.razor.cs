using BlazorComponent;
using HelperApp.Domain;

namespace HelperApp.Pages;

partial class MainLayout
{
    bool drawer;
    StringNumber group;
    private readonly List<MainItems> mainItems = new List<MainItems>();
    protected override void OnInitialized()
    {
        mainItems.Add(new MainItems
        {
            Icon = "mdi-home",
            Title = "首页",
            Href = "/"
        });

        mainItems.Add(new MainItems
        {
            Icon = "mdi-wrench",
            Title = "功能",
            Href = "/function"
        });

        mainItems.Add(new MainItems
        {
            Icon = "mdi-briefcase-variant-outline",
            Title = "关于",
            Href = "/about"
        });

        // 如果是webassembly不展示关于界面
        if(AppEnvironment.GetAppEnvironment() != AppEnvironmentType.WebAssembly)
        {

        }
    }

}
