using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using HostnoMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HostnoMore.ViewModels
{
    public class EntreeViewModel : ViewModelBase
    {
        public EntreeViewModel(INavigationService navigationService)
              : base(navigationService)
        {

        }

        private Entree _EntreeDetail;
        public Entree EntreeDetail
        {
            get { return _EntreeDetail; }
            set { SetProperty(ref _EntreeDetail, value); }
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            EntreeDetail = (Entree)parameters["Entree"];
            Title = EntreeDetail.entreeTitle;
            base.OnNavigatedTo(parameters);
        }
    }
}
