using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Powah
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            try
            {
                if (Plugin.Settings.CrossSettings.Current.GetValueOrDefault("FirstStart", true, "PowahSettings"))
                {
                    Current.MainPage.Navigation.PushAsync(new FirstRunPage());
                }
            }
            catch (Exception ex)
            {
                Current.MainPage.DisplayAlert("Error", "Error while saving settings", "Ok");
                //log error
            }
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            
        }

        protected override void OnResume()
        {
            
        }
    }
}
