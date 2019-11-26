using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using HostnoMore.Models;
using HostnoMore.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using Plugin.ExternalMaps;

namespace HostnoMore.ViewModels
{
    public class LoginPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        public DelegateCommand loginButton { get; set; }
        public DelegateCommand RegisterButton { get; set; }

        private string rest_id;
        public string restID
        {
            get { return rest_id; }
            set { SetProperty(ref rest_id, value); }
        }

        private string rest_password;
        public string restPassword
        {
            get { return rest_password; }
            set { SetProperty(ref rest_password, value); }
        }

        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            loginButton = new DelegateCommand(GoToMainPage);
            RegisterButton = new DelegateCommand(GoToRegister);
        }

        private async void GoToMainPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoToMainPage)}");

            await _navigationService.NavigateAsync("MainPage", null);

        }

        private async void GoToRegister()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoToRegister)}");

            await _navigationService.NavigateAsync("RegisrationPage", null);

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedFrom)}");
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedTo)}");
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatingTo)}");
        }
    }
}

