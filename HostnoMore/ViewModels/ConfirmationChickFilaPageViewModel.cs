using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using HostnoMore.Models;
using HostnoMore.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace HostnoMore.ViewModels
{
    public class ConfirmationChickFilaPageViewModel : BindableBase, INavigationAware
    {
        IPageDialogService displayMessage;
        INavigationService nav_service;
        IRepository _repo;

        public DelegateCommand AnotherOrder { get; set; }

        private string foodDelivery;
        public string FoodDelivery
        {
            get { return foodDelivery; }
            set { SetProperty(ref foodDelivery, value); }
        }

        public ConfirmationChickFilaPageViewModel(IPageDialogService pageDialogService, INavigationService navigationService, IRepository repository)
        {
            displayMessage = pageDialogService;
            nav_service = navigationService;
            _repo = repository;

            FoodDelivery = "Food out for delivery";

            AnotherOrder = new DelegateCommand(GoToHomePage);
        }

        private async void GoToHomePage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoToHomePage)}");
            await nav_service.NavigateAsync("MainPage", null);
            Restaurant2SideItem foodToDeliver = new Restaurant2SideItem
            {
                Item = this.FoodDelivery
            };

            await _repo.AddItem(foodToDeliver);
            var navParams = new NavigationParameters();
            navParams.Add("ItemAdded", navParams);
            await Task.Delay(1);
            // _repo.RemoveAllItems(listOfItems);
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