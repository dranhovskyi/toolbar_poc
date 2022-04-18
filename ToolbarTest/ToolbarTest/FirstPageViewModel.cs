using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;

namespace ToolbarTest
{
    internal class FirstPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IToolbarViewModel _toolbarViewModel;

        public FirstPageViewModel(INavigationService navigationService, IToolbarViewModel toolbarViewModel)
        {
            _navigationService = navigationService;
            _toolbarViewModel = toolbarViewModel;
            FirstCommand = new Command(async () => { await _navigationService.NavigateAsync("SecondPage"); });
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            _toolbarViewModel.Title = "First Page";
        }

        public ICommand FirstCommand { get; set; }

        public string Title { get; set; } = "First";
    }
}
