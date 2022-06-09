using Prism.Ioc;
using Xamarin.Forms;

namespace ToolbarTest
{
    public class ToolbarContentPage : ContentPage
    {
        public ToolbarContentPage()
        {
            // Set ToolbarView as a TitleView of navigation bar
            var toolbarView = ContainerLocator.Container.Resolve<ToolbarView>();
            toolbarView.BindingContext = toolbarView.BindingContext ?? ContainerLocator.Container.Resolve<IToolbarViewModel>();
            NavigationPage.SetTitleView(this, toolbarView);
            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, false);
        }
    }

    public class NavigationContentPage : ContentPage
    {
        public NavigationContentPage()
        {
            // Disable the native navigation bar
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}
