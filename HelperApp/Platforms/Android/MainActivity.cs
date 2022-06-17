using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;

namespace HelperApp;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    /// <summary>
    /// 权限状态码
    /// </summary>
    private const int REQUESTCODE = 1314;
    private string[] Permissions = new string[] { Manifest.Permission.Camera, Manifest.Permission.WriteExternalStorage };
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        CheckPermission();

    }

    private void CheckPermission()
    {
        ActivityCompat.RequestPermissions(this, Permissions, REQUESTCODE);
    }

    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
    {
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        for(int i = 0;i < permissions.Length;i++)
        {
            var permission = grantResults[i];
            // 用户同意的权限
            if(permission == Permission.Granted)
            {

            }
        }
    }
}
