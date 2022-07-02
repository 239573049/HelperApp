using HelperApp.Domain;
using Token.HttpClientHelper;
using Token.Inject;

namespace HelperApp.Applications;

public static class HelperAppApplicationsTag
{
    public static void AddApplicationsTag(this IServiceCollection services)
    {
        services.AddAutoInject(typeof(HelperAppApplicationsTag));
        services.AddTokenHttpHelperInject("http://dev.tokengo.top:31005/");
        services.AddMasaBlazor();

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
