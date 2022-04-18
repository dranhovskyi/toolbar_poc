using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Navigation;
using Xamarin.Forms;

namespace ToolbarTest
{
    public partial class App : PrismApplicationBase
    {
        public App(IPlatformInitializer initializer) : base(initializer)
        {
            MainPage = new ContentPage { Content = new Label { Text = "Hello world!" } };
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            var toolbarView = Application.Current.Resources["ToolbarViewKey"] as ToolbarView;
            toolbarView.BindingContext = Container.Resolve<IToolbarViewModel>();
        }

        protected override void Initialize()
        {
            base.Initialize();
            NavigationService = Container.Resolve<INavigationService>();
        }

        protected override IContainerExtension CreateContainerExtension()
        {
            return new DryIocContainerExtension();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IToolbarViewModel, ToolbarViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>("Navigation");
            containerRegistry.RegisterForNavigation<FirstPage, FirstPageViewModel>();
            containerRegistry.RegisterForNavigation<SecondPage, SecondPageViewModel>();
            containerRegistry.RegisterForNavigation<ThirdPage, ThirdPageViewModel>();
        }

        protected override async void OnStart()
        {
            base.OnStart();

            await NavigationService.NavigateAsync("/Navigation/FirstPage");
        }
    }
}
