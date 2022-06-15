namespace HelperApp.Domain;

public class AppEnvironment
{
    private static AppEnvironmentType AppEnvironmentType { get; set; }

    /// <summary>
    /// 设置环境变量
    /// </summary>
    /// <param name="environment"></param>
    public static void SetEnvironment(AppEnvironmentType environment)
    {
        AppEnvironmentType = environment;
    }

    /// <summary>
    /// 获取环境变量
    /// </summary>
    /// <returns></returns>
    public static AppEnvironmentType GetAppEnvironment()
    {
        return AppEnvironmentType;
    }
}
