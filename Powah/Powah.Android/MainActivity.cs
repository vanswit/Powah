
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Powah.Droid
{
    [Activity(Label = "Powah", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CopyDatabase("PowahDB.db");
            LoadApplication(new App());
        }

        private void CopyDatabase(string dataBaseName)
        {
            var dbPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dataBaseName);

            if (!System.IO.File.Exists(dbPath))
            {
                var dbAssetStream = Assets.Open(dataBaseName);
                var dbFileStream = new System.IO.FileStream(dbPath, System.IO.FileMode.OpenOrCreate);
                var buffer = new byte[1024];

                int b = buffer.Length;
                int length;

                while ((length = dbAssetStream.Read(buffer, 0, b)) > 0)
                {
                    dbFileStream.Write(buffer, 0, length);
                }

                dbFileStream.Flush();
                dbFileStream.Close();
                dbAssetStream.Close();
            }
        }
    }
}