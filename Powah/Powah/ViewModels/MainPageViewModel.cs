using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Powah
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly DelegateCommand _GeneralSettingsCommand;
        public ICommand GeneralSettingsCommand => _GeneralSettingsCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            _GeneralSettingsCommand = new DelegateCommand(OnGeneralSettingsCommand);
        }

        private void OnGeneralSettingsCommand(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new GeneralSettingsPage());
        }
    }
}
