using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using App3.DependencyServices;
using App3.Droid.DependencyServices;
using Xamarin.Forms;
using Android.Telephony;

[assembly: Xamarin.Forms.Dependency(typeof(UtilityDependencyService))]
namespace App3.Droid.DependencyServices
{
    public class UtilityDependencyService : IUtilityDependencyService
    {
        /// <summary>
        /// Show Toast
        /// </summary>
        /// <param name="message"></param>
        public void ShowToast(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }

        public string GetIdentifier()
        {
            TelephonyManager manager = (TelephonyManager)Forms.Context.GetSystemService(Android.Content.Context.TelephonyService);
            return manager.Imei;
        }

    }
}