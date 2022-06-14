using Token.Inject.tag;

namespace HelperApp.Applications.AppService;

public class HelperService : ISingletonTag
{
    public string GetPath()
    {
        string path = string.Empty;

#if ANDROID
        path=Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).Path,"helper");

#elif WINDOWS
        path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "helper");
#endif
        if(!Directory.Exists(path))
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch(Exception)
            {
                throw new Exception("创建存储目录失败");
            }
        }

        return path;
    }
}
