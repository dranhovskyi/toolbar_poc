using Android.Content;
using Android.Util;
using ToolbarTest;
using ToolbarTest.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.Android;
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
                int barHeight = ActionBarHeight();

                bool toolbarLayoutCompleted = false;
                for (var i = 0; i < ChildCount; i++)
                {
                    AView child = GetChildAt(i);

                    _toolbar.Layout(0, b - barHeight, r - l, b);
                    
                    if (!(child is AndroidX.AppCompat.Widget.Toolbar))
                    {
                        child.Layout(0, 0, r - l, b - barHeight);
                    }

                    toolbarLayoutCompleted = true;
                }

                if (!toolbarLayoutCompleted)
                {
                    _toolbar.Layout(0, b - barHeight, r - l, b);
                }
            }
        }

        private int ActionBarHeight()
        {
            var attr = Resource.Attribute.actionBarSize;

            int actionBarHeight;
            using (var tv = new TypedValue())
            {
                actionBarHeight = 0;
                if (Context.Theme.ResolveAttribute(attr, tv, true))
                    actionBarHeight = TypedValue.ComplexToDimensionPixelSize(tv.Data, Resources.DisplayMetrics);
            }

            if (actionBarHeight <= 0)
                return Device.Info.CurrentOrientation.IsPortrait() ? (int)Context.ToPixels(56) : (int)Context.ToPixels(48);

            return actionBarHeight;
        }
    }
}
