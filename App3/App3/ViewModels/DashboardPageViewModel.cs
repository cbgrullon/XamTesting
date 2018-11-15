using App3.Models;
using App3.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App3.ViewModels
{
    public class DashboardPageViewModel : BaseViewModel
    {
        JsonPlaceHolderService service = null;

        #region Properties
        ObservableCollection<User> _users;
        public ObservableCollection<User> Users {
            get => _users;
            set {
                _users = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand OnGetUsersCommand { get; private set; }
        #endregion

        public DashboardPageViewModel()
        {
            this.Title = "Dashboard Page";

            service = new JsonPlaceHolderService();
            OnGetUsersCommand = new Command(async () => {
                await OnGetUsersHandler();
            });
        }

        private async Task OnGetUsersHandler()
        {
            var response = await service.GetUsersAsync();
            if (response?.Count > 0)
            {
                Users = new ObservableCollection<User>();
                response.ForEach(item => {
                    Users.Add(item);
                });
            }
        }
    }
}
