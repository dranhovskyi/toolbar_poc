using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;

namespace ToolbarTest
{
    public class SecondPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public SecondPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            SecondCommand = new Command(async () => { await _navigationService.NavigateAsync("ThirdPage"); });
        }

        public string Title { get; set; } = "Second";

        public ICommand SecondCommand { get; set; }
    }
}