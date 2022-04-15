using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;

namespace ToolbarTest
{
    internal class FirstPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public FirstPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            FirstCommand = new Command(async () => { await _navigationService.NavigateAsync("SecondPage"); });
        }

        public string Title { get; set; } = "First";

        public ICommand FirstCommand { get; set; }
    }
}
