using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Powah
{
    public class GeneralSettingsViewModel : INotifyPropertyChanged
    {
        public string UserName { get; set; }
        public int Age { get; set; }
        public int Weigth { get; set; }
        public int DeadliftMax { get; set; }
        public int FlatbenchMax { get; set; }
        public int SquatMax { get; set; }

        private readonly DelegateCommand _ResetCommand;
        public ICommand ResetCommand => _ResetCommand;

        private readonly DelegateCommand _UpdateCommand;
        public ICommand UpdateCommand => _UpdateCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public GeneralSettingsViewModel()
        {
            _ResetCommand = new DelegateCommand(OnReset);
            _UpdateCommand = new DelegateCommand(OnUpdate);
            GetGeneralSettings();
        }

        private void OnUpdate(object obj)
        {
            PowahUser powahUser = new PowahUser(
                UserName,
                Age,
                Weigth,
                DeadliftMax,
                FlatbenchMax,
                SquatMax
                );

            try
            {
                PowahUserDA.SaveToSettings(powahUser);

                GetGeneralSettings();

                OnPropertyChanged("UserName");
                OnPropertyChanged("Age");
                OnPropertyChanged("Weigth");
                OnPropertyChanged("DeadliftMax");
                OnPropertyChanged("FlatbenchMax");
                OnPropertyChanged("SquatMax");
            }
            catch (Exception ex)
            {
                //Log error
            }
        }

        private void OnReset(object obj)
        {
            try
            {
                Plugin.Settings.CrossSettings.Current.Clear("PowahSettings");

                GetGeneralSettings();

                OnPropertyChanged("UserName");
                OnPropertyChanged("Age");
                OnPropertyChanged("Weigth");
                OnPropertyChanged("DeadliftMax");
                OnPropertyChanged("FlatbenchMax");
                OnPropertyChanged("SquatMax");
            }
            catch (Exception ex)
            {
                //Log error
            }
            Application.Current.MainPage.DisplayAlert("Info","Powah settings have been reset.","Ok");
            Application.Current.MainPage.Navigation.PopAsync();
        }

        private void GetGeneralSettings()
        {
            PowahUser user = PowahUserDA.GetUser();

            UserName = user.UserName;
            Age = user.DeadliftMax;
            Weigth = user.Weigth;
            DeadliftMax = user.DeadliftMax;
            FlatbenchMax = user.FlatBenchMax;
            SquatMax = user.SquatMax;
        }
    }
}
