using App3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DashboardPage : ContentPage
	{
        DashboardPageViewModel vm = null;
		public DashboardPage ()
		{
			InitializeComponent ();
            BindingContext = vm = new DashboardPageViewModel();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.OnGetUsersCommand.Execute(null);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            lvUsers.SelectedItem = null;
        }
    }
}