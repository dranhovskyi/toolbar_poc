using Android.Content;
using ToolbarTest;
using ToolbarTest.Droid;
using Xamarin.Forms;
using AView = Android.Views.View;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(MainPage), typeof(CustomNavigationPageRenderer))]
namespace ToolbarTest.Droid
{
    internal class CustomNavigationPageRenderer : NavigationPageRenderer
    {
        Context _context;

        AndroidX.AppCompat.Widget.Toolbar _toolbar;

        public CustomNavigationPageRenderer(Context context) : base(context)
        {
            _context = context;
        }

        public override void OnViewAdded(Android.Views.View child)
        {
            base.OnViewAdded(child);
            if (child.GetType() == typeof(AndroidX.AppCompat.Widget.Toolbar))
            {
                _toolbar = (AndroidX.AppCompat.Widget.Toolbar)child;
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            if (_toolbar != null)
            {
                int barHeight = _toolbar.Height;
            }
        }
    }
}
