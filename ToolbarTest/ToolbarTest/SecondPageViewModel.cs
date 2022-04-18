using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;

namespace ToolbarTest
{
    public class SecondPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IToolbarViewModel _toolbarViewModel;

        public SecondPageViewModel(INavigationService navigationService, IToolbarViewModel toolbarViewModel)
        {
            _navigationService = navigationService;
            _toolbarViewModel = toolbarViewModel;
            SecondCommand = new Command(async () => { await _navigationService.NavigateAsync("ThirdPage"); });
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            _toolbarViewModel.Title = "Second Page";
        }

        public ICommand SecondCommand { get; set; }

        public string Title { get; set; } = "Second";
    }
}