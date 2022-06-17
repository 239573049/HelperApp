using HelperApp.Applications;
using Microsoft.Extensions.DependencyInjection;

namespace HelperApp.Pages;
public static class HelperAppPagesTag
{
    public static void AddPages(this IServiceCollection services)
    {
        services.AddApplicationsTag();
    }
}
