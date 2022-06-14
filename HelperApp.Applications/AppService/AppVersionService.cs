using HelperApp.Domain;
using Token.HttpClientHelper;
using Token.Inject.tag;

namespace HelperApp.Applications.AppService;

public class AppVersionService : ISingletonTag
{
    public readonly TokenHttp _tokenHttp;

    public AppVersionService(TokenHttp tokenHttp)
    {
        _tokenHttp = tokenHttp;
    }

    public async Task<AppVersion> GetAppVersionAsync()
    {
        var result = await _tokenHttp.GetAsync<ResponseView<AppVersion>>("api/AppVersion/app-version/" + Constant.Code);
        if(result.Code == "200")
        {
            return result.Data;
        }
        throw new Exception("获取版本信息错误");
    }
}
