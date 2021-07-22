using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;

namespace SoccerBet.Android
{
    [Activity(Label = "SoccerBet", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDc2NzcyQDMxMzkyZTMyMmUzMG9TTUd3dmNoTDFTK2tnM1I5ZWFWencraVoreVpsTG01ZHJ3blJJZnI1U1E9");

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

