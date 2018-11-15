using App3.DependencyServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App3.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region Properties
        string _username;
        public string Username {
            get => _username;
            set {
                _username = value;
                OnPropertyChanged();
            }
        }

        string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Commands
        public ICommand OnClickCommand { get; private set; }
        public ICommand OnLoginCommand { get; private set; }
        public ICommand OnCancelCommand { get; private set; }
        #endregion

        public LoginPageViewModel()
        {
            this.Title = "Main Page";
            OnClickCommand = new Command(OnClick);
            OnLoginCommand = new Command(async()=> {
                await OnLoginHandler();
            });
            OnCancelCommand = new Command(OnCancelHandler);
        }

        private void OnCancelHandler()
        {
            var dependecy = DependencyService.Get<IUtilityDependencyService>();
            if (dependecy!=null)
            {
                string imei = dependecy.GetIdentifier();
                dependecy.ShowToast(imei);
            }
        }

        private async Task OnLoginHandler()
        {
            this.IsBusy = true;
            await Task.Delay(3000);
            this.IsBusy = false;

            if (string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Password))
            {
                DisplayAlert("Empty Fields", "Complete All");
            }else
            {
                await App.Current.MainPage.Navigation.PushAsync(new Views.DashboardPage());
            }
        }

        void DisplayAlert(string title, string message, string cancelButtonText = "OK") =>
            App.Current.MainPage.DisplayAlert(title, message, cancelButtonText);

        private void OnClick(object obj)
        {
            App.Current.MainPage.DisplayAlert("Hola", "Alerta","OK");
        }
    }
}
