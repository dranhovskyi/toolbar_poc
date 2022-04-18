using Prism.Navigation;

namespace ToolbarTest
{
    internal class ThirdPageViewModel : BaseViewModel
    {
        private readonly IToolbarViewModel _toolbarViewModel;

        public ThirdPageViewModel(IToolbarViewModel toolbarViewModel)
        {
            _toolbarViewModel = toolbarViewModel;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            _toolbarViewModel.Title = "Third Page";
        }

        public string Title { get; set; } = "Third";
    }
}
