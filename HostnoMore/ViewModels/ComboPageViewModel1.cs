using Prism.Commands;
using Prism.Navigation;
using HostnoMore.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace HostnoMore.ViewModels
{
    public class ComboPageViewModel1 : ViewModelBase
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
                BlogDescription = "DOUBLE–DOUBLE ® with fries and a Drink ",
                BlogTitle = "Combo 1",
                CreatedDate = DateTime.Now,
                CreatedBy = "Price: $6.70",
                imageName = "double_double_meal.png"
            },

            new Blog
            {
                BlogDescription = "Cheeseburger with Fries and a Drink",
                BlogTitle = "Combo 2",
                CreatedDate = DateTime.Now,
                CreatedBy = "Price: $5.65",
                imageName = "cheeseburger_meal.png"
            },


            new Blog
            {
                BlogDescription = "Hamburger with Fries and a Drink",
                BlogTitle = "Combo 3",
                CreatedDate = DateTime.Now,
                CreatedBy = "Price: $5.35",
                imageName = "combo3.png"
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
        public ComboPageViewModel1(INavigationService navigationService)
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
