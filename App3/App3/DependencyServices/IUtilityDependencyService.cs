using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App3.DependencyServices
{
    public interface IUtilityDependencyService
    {
        void ShowToast(string message);
        string GetIdentifier();
    }
}
