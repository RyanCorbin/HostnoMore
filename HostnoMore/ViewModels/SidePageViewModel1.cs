using Prism.Commands;
using Prism.Navigation;
using HostnoMore.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace HostnoMore.ViewModels
{
    public class SidePageViewModel1 : ViewModelBase
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
                BlogDescription = "Soft Drink",
                BlogTitle = "Soft Drink",
                CreatedDate = DateTime.Now,
                CreatedBy = "Price: $1.55",
                imageName = "in-nout-drinks.jpeg"
            },

            new Blog
            {
                BlogDescription = "Shakes: CHOCOLATE, STRAWBERRY OR VANILLA MADE WITH REAL ICE CREAM",
                BlogTitle = "Shakes",
                CreatedDate = DateTime.Now,
                CreatedBy = "Price: $2.45",
                imageName = "In-Out-milkshake(1).png"
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
        public SidePageViewModel1(INavigationService navigationService)
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
