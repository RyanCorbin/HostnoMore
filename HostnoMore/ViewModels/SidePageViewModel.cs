using Prism.Commands;
using Prism.Navigation;
using HostnoMore.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using HostnoMore.Services;
using System.Threading.Tasks;
using Prism.Services;

namespace HostnoMore.ViewModels
{
    public class SidePageViewModel : ViewModelBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public DelegateCommand NavigateToBlogCommand { get; private set; }

        private List<Blog> _blogs = new List<Blog>()
        {
            new Blog
            {
                BlogDescription = "Chicken Sandwitch with fries and a Drink ",
                BlogTitle = "Combo 1",
                CreatedDate = DateTime.Now,
                CreatedBy = "Price: 9.75$",
                imageName = "chickenSandwitch.jpg"
            },

            new Blog
            {
                BlogDescription = "Spicy Chicken Sandwitch with Fries and a Drink",
                BlogTitle = "Combo 2",
                CreatedDate = new DateTime(2017,12,30),
                CreatedBy = "Price: 9.75$",
                imageName = "SpicyChicken.jpg"
            },


            new Blog
            {
                BlogDescription = "Chicken Nuggets  with Fries and a Drink",
                BlogTitle = "Combo 3",
                CreatedDate = new DateTime(2017,11,30),
                CreatedBy = "Price: 8.50$",
                imageName = "ChickenNuggets2.jpg"
            },


            new Blog
            {
                BlogDescription = "Salad",
                BlogTitle = "Combo 4",
                CreatedDate = new DateTime(2017,10,30),
                CreatedBy = "Price: 7.45",
                imageName = "ChickenNuggets2.jpg"
            },

        };

        private Blog _selectedBlog;
        public Blog SelectedBlog
        {
            get { return _selectedBlog; }
            set { SetProperty(ref _selectedBlog, value); }
        }

        public List<Blog> Blogs
        {
            get { return _blogs; }
            set { SetProperty(ref _blogs, value); }
        }
        public SidePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Blogs";
            NavigateToBlogCommand = new DelegateCommand(NavigateToBlog, () => SelectedBlog != null).ObservesProperty(() => SelectedBlog);

        }

        public DelegateCommand _navigateCommand;
        private readonly INavigationService _navigationService;

        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        async void ExecuteNavigateCommand()
        {
            await _navigationService.NavigateAsync("");
        }
        private void NavigateToBlog()
        {
            var parameter = new NavigationParameters();
            parameter.Add("Blog", SelectedBlog);
            NavigationService.NavigateAsync("Blog", parameter);
        }
    }
}
