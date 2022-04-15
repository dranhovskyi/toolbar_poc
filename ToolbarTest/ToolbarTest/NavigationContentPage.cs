using Xamarin.Forms;

namespace ToolbarTest
{
    public class NavigationContentPage : ContentPage
    {
        public NavigationContentPage()
        {
            NavigationPage.SetTitleView(this, Application.Current.Resources["ToolbarViewKey"] as ToolbarView);
        }
    }
}
