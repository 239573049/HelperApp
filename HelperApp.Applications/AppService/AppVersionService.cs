using HelperApp.Domain;
using Token.HttpClientHelper;
using Token.Inject.tag;

namespace HelperApp.Applications.AppService;

public class AppVersionService : IScopedTag
{
    public readonly TokenHttp _tokenHttp;
    public AppVersionService(TokenHttp tokenHttp)
    {
        _tokenHttp = tokenHttp;
    }

    public async Task<AppVersion> GetAppVersionAsync()
    {
        var message = await _tokenHttp.GetAsync<ResponseView<AppVersion>>("api/AppVersion/app-version/" + Constant.Code);

        if(message.Code == "200")
        {
            return message.Data;
        }
        else
        {
            throw new Exception(message?.Message ?? "获取版本信息错误");
        }
    }
}
