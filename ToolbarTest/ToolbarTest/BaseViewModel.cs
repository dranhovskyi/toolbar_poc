using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation;

namespace ToolbarTest
{
    public class BaseViewModel : BindableBase, INavigatedAware
    {

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }
    }
}
