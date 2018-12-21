using Powah.BO;
using Powah.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Powah
{
    public class FirstRunPageViewModel : INotifyPropertyChanged
    {
        public string UserName { get; set; }
        public int Age { get; set; }
        public int Weigth { get; set; }
        public int DeadliftMax { get; set; }
        public int FlatbenchMax { get; set; }
        public int SquatMax { get; set; }

        private readonly DelegateCommand _SaveCommand;
        public ICommand SaveCommand => _SaveCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public FirstRunPageViewModel()
        {
            _SaveCommand = new DelegateCommand(OnSave);
        }

        private void OnSave(object obj)
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
                Plugin.Settings.CrossSettings.Current.AddOrUpdateValue("FirstStart", false, "PowahSettings");
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Error while saving settings", "Ok");
                //log error
            }

            //Create program DB entries using settings

            

            Application.Current.MainPage.DisplayAlert("Info", "Programs have been generated.", "Ok");
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
