using Prism.Mvvm;

namespace ToolbarTest
{
    public class ToolbarViewModel : BindableBase, IToolbarViewModel
    {
        private string _title = "Default";

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
    }
}