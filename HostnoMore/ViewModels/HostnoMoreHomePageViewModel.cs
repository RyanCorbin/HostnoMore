﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Plugin.ExternalMaps;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace HostnoMore.ViewModels
{
    public class HostnoMoreHomePageViewModel : BindableBase
    {
      //  public ObservableCollection<Pin> Pins { get; set; }

        //public Command<MapClickedEventArgs> MapClickedCommand =>
        //new Command<MapClickedEventArgs>(args =>
        //{
        //    Pins.Add(new Pin
        //    {
        //        Label = $"In-N-Out",
        //        Position = new Position(33.1372, -117.1772)//args.Point
        //    });
        //    Pins.Add(new Pin
        //    {
        //        Label = $"ChickFila",
        //        Position = new Position(33.141546, -117.191186)//args.Point
        //    });
        //});

        INavigationService _navigationService;
        public DelegateCommand GoToRestaurantSide { get; set; }
        //public DelegateCommand GoToMapCommand { get; set; }
        public DelegateCommand searchActivated { get; set; }
        public DelegateCommand<string> SuggestionTappedCommand { get; set; }
        //public DelegateCommand<string> RestaurantSelectedCommand { get; set; }

        private string enter_restaurant;
        public string EnterRestaurant
        {
            get { return enter_restaurant; }
            set { SetProperty(ref enter_restaurant, value); }
        }

        //private Map my_map;
        //public Map MyMap
        //{
        //    get { return my_map; }
        //    set { SetProperty(ref my_map, value); }
        //}

        private bool is_visible;
        public bool IsVisible
        {
            get { return is_visible; }
            set { SetProperty(ref is_visible, value); }
        }

        //private string _selectedRestaurant;
        //public string SelectedRestaurant
        //{
        //    get { return _selectedRestaurant; }
        //    set { SetProperty(ref _selectedRestaurant, value); }
        //}

        List<string> restaurants = new List<string>
        {
            "In-N-Out Burger",
            "ChickFila"
        };

        //private List<string> my_restaurant = new List<string>();
        //public List<string> MyRestaurant
        //{ get { return my_restaurant; } set { SetProperty(ref my_restaurant, value); } }

        private List<string> _suggestions = new List<string>();
        public List<string> Suggestions
        { get { return _suggestions; } set { SetProperty(ref _suggestions, value); } }

        public HostnoMoreHomePageViewModel(INavigationService navigationService)
        {
            Debug.WriteLine($"**** {this.GetType().Name}: ctor");

            _navigationService = navigationService;

            GoToRestaurantSide = new DelegateCommand(RestaurantSide);
            //GoToMapCommand = new DelegateCommand(GoToMap);
            searchActivated = new DelegateCommand(GoToSearch);
            SuggestionTappedCommand = new DelegateCommand<string>(OnSuggestionTapped);
            //RestaurantSelectedCommand = new DelegateCommand<string>(OnRestSelected);
        }

        //private void OnRestSelected(string restSelected)
        //{
        //    Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnRestSelected)}:  {restSelected}");
        //}

        private async void RestaurantSide()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RestaurantSide)}");

            await _navigationService.NavigateAsync("LoginPage", null);
        }

        private void GoToSearch()
        {
            if (enter_restaurant.Length >= 1)
            {
                Suggestions = restaurants.Where(c => c.ToLower().Contains(enter_restaurant.ToLower())).ToList();

                IsVisible = true;
            }
            else
            {
                IsVisible = false;
            }
        }

        public async void OnSuggestionTapped(string suggestionTapped)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnSuggestionTapped)}:  {suggestionTapped}");

            if (suggestionTapped == "In-N-Out Burger")
            {
                await _navigationService.NavigateAsync("ChooseSeatingPage", null);
                IsVisible = false;
            }
            else if (suggestionTapped == "ChickFila")
            {
                await _navigationService.NavigateAsync("ChickFilaSeatPage", null);
                IsVisible = false;
            }
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

        //private void GoToMap()
        //{
        //    Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoToMap)}");
        //    CrossExternalMaps.Current.NavigateTo("In-N-Out Burger", "583 Grand Ave", "San Marcos", "CA", "92078", "USA", "USA");
        //}
    }

}