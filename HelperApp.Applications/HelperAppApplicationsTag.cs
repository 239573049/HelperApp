using Token.HttpClientHelper;
using Token.Inject;

namespace HelperApp.Applications;

// All the code in this file is included in all platforms.
public static class HelperAppApplicationsTag
{
    public static void AddApplicationsTag(this IServiceCollection services)
    {
        services.AddAutoInject(typeof(HelperAppApplicationsTag));
        services.AddTokenHttpHelperInject("http://192.168.0.101:5000/");
    }
}
