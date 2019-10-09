using Prism.Navigation;
using HostnoMore.Models;

namespace HostnoMore.ViewModels
{
    public class BlogViewModel : ViewModelBase
	{
        public BlogViewModel(INavigationService navigationService)
            : base(navigationService)
        {
               
        }

        private Blog _blogDetail;
        public Blog BlogDetail
        {
            get { return _blogDetail; }
            set { SetProperty(ref _blogDetail, value); }
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            BlogDetail = (Blog)parameters["Blog"];
            Title = BlogDetail.BlogTitle;
            base.OnNavigatedTo(parameters);
        }
    }
}
