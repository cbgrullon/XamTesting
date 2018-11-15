using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App3.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        string _title;
        public string Title {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        bool _isBusy;
        public bool IsBusy {
            get => _isBusy;
            set {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "") =>
               this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
