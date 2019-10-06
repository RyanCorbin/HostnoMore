using System;
using System.Diagnostics;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HostnoMore.Views;
using HostnoMore.ViewModels;
using HostnoMore.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HostnoMore
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer){}

        protected override async void OnInitialized()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnInitialized)})");
            InitializeComponent();

            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}");
        }

        protected override void RegisterTypes(Prism.Ioc.IContainerRegistry containerRegistry)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RegisterTypes)})");
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, HostnoMoreHomePageViewModel>();
            containerRegistry.RegisterForNavigation<CallsPage, CallsPageViewModel>();
            containerRegistry.RegisterForNavigation<CallsChickFilaPage, CallsChickFilaPageViewModel>();
            containerRegistry.RegisterForNavigation<ChooseSeatingPage, ChooseSeatingPageViewModel>();
            containerRegistry.RegisterForNavigation<ChickFilaSeatPage, ChickFilaSeatPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuOneContainerPage, MenuOneContainerPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuTwoContainerPage, MenuTwoContainerPageViewModel>();
            containerRegistry.RegisterForNavigation<TabMealPage, TabMealPageViewModel>();
            containerRegistry.RegisterForNavigation<TabIndivItemPage, TabIndivItemPageViewModel>();
            containerRegistry.RegisterForNavigation<TabDrinkPage, TabDrinkPageViewModel>();
            containerRegistry.RegisterForNavigation<TabSideAndDrinksPage, TabSideAndDrinksPageViewModel>();
            containerRegistry.RegisterForNavigation<TabSandwichesPage, TabSandwichesPageViewModel>();
            containerRegistry.RegisterForNavigation<CartChickFilaPage, CartChickFilaPageViewModel>();
            containerRegistry.RegisterForNavigation<CartPage, CartPageViewModel>();
            containerRegistry.RegisterForNavigation<CashPage, CashPageViewModel>();
            containerRegistry.RegisterForNavigation<PaymentPage, PaymentPageViewModel>();
            containerRegistry.RegisterForNavigation<CreditInfoPage, CreditInfoPageViewModel>();
            containerRegistry.RegisterForNavigation<PaymentChickFilaPage, PaymentChickFilaPageViewModel>();
            containerRegistry.RegisterForNavigation<CreditInfoChickFilaPage, CreditInfoChickFilaPageViewModel>();
            containerRegistry.RegisterForNavigation<ConfirmationPage, ConfirmationPageViewModel>();
            containerRegistry.RegisterForNavigation<RestaurantSidePage, RestaurantSidePageViewModel>();
            containerRegistry.RegisterForNavigation<ConfirmationChickFilaPage, ConfirmationChickFilaPageViewModel>();
            containerRegistry.RegisterSingleton<IRepository, Repository>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
