using HelperApp.Domain;
using Token.HttpClientHelper;
using Token.Inject;

namespace HelperApp.Applications;

// All the code in this file is included in all platforms.
public static class HelperAppApplicationsTag
{
    public static void AddApplicationsTag(this IServiceCollection services)
    {
        services.AddAutoInject(typeof(HelperAppApplicationsTag));
        services.AddTokenHttpHelperInject("http://www.tokengo.top:8000/");
#if ANDROID
        AppEnvironment.SetEnvironment(AppEnvironmentType.Android);
#elif WINDOWS
        AppEnvironment.SetEnvironment(AppEnvironmentType.Windows);
#elif IOS
        AppEnvironment.SetEnvironment(AppEnvironmentType.IOS);
#elif MACCATALYST
        AppEnvironment.SetEnvironment(AppEnvironmentType.MAC);
#else
        AppEnvironment.SetEnvironment(AppEnvironmentType.WebAssembly);
#endif
    }
}
