using System;
using System.Diagnostics;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace HostnoMore.ViewModels
{
    public class LoginPageViewModel : BindableBase, INavigationAware
    {
        INavigationService nav_service;
        IPageDialogService _pageDialogService;

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

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            nav_service = navigationService;
            _pageDialogService = pageDialogService;
            loginButton = new DelegateCommand(GoToMainPage);
            RegisterButton = new DelegateCommand(GoToRegister);
        }

        private async void GoToMainPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(loginButton)}");

            await nav_service.NavigateAsync("HostnoMoreHomePageViewModel", null);

        }

        private async void GoToRegister()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RegisterButton)}");

            await nav_service.NavigateAsync("RegisrationViewModel", null);

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

