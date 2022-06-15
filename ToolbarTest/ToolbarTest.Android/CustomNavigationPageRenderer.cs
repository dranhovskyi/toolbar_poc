using System.Reflection;
using Android.Content;
using Android.Util;
using AndroidX.AppCompat.Widget;
using ToolbarTest;
using ToolbarTest.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(MainPage), typeof(CustomNavigationPageRenderer))]
namespace ToolbarTest.Droid
{
    internal class CustomNavigationPageRenderer : NavigationPageRenderer
    {
        private Toolbar _toolbar;

        public CustomNavigationPageRenderer(Context context)
            : base(context)
        {
        }

        public override void OnViewAdded(Android.Views.View child)
        {
            base.OnViewAdded(child);
            if (child.GetType() == typeof(Toolbar))
            {
                _toolbar = (Toolbar)child;
                _toolbar.SetContentInsetsAbsolute(0, 0);
                _toolbar.SetContentInsetsRelative(0, 0);
                _toolbar.ContentInsetStartWithNavigation = 0;
                _toolbar.SetPadding(0, 0, 0, 0);
                _toolbar.SetBackgroundColor(Color.Transparent.ToAndroid());
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            if (_toolbar == null)
            {
                return;
            }

            var barHeight = ActionBarHeight();
            for (var i = 0; i < ChildCount; i++)
            {
                var child = GetChildAt(i);
                if (child?.GetType().Name == "PageContainer")
                {
                    var propertyInfo = child.GetType()?.GetProperty("Child", BindingFlags.Public | BindingFlags.Instance);
                    var visualElement = (IVisualElementRenderer)propertyInfo?.GetValue(child);
                    if (!(visualElement?.Element is Page childPage))
                    {
                        return;
                    }

                    // We need to base the layout of both the child and the bar on the presence of the NavBar on the child Page itself.
                    // If we layout the bar based on ToolbarVisible, we get a white bar flashing at the top of the screen.
                    // If we layout the child based on ToolbarVisible, we get a white bar flashing at the bottom of the screen.
                    var childHasNavBar = NavigationPage.GetHasNavigationBar(childPage);
                    if (childHasNavBar)
                    {
                        child?.Layout(0, 0, r - l, b - barHeight + 30);
                        _toolbar.Layout(0, b - barHeight - 30, r - l, b);
                    }
                    else
                    {
                        child?.Layout(0, 0, r, b);
                        _toolbar.Layout(0, -1000, r, barHeight - 1000);
                    }
                }
            }
        }

        private int ActionBarHeight()
        {
            const int attr = Resource.Attribute.actionBarSize;
            var actionBarHeight = 0;
            using (var typedValue = new TypedValue())
            {
                if (Context?.Theme != null && Context.Theme.ResolveAttribute(attr, typedValue, true))
                {
                    actionBarHeight = TypedValue.ComplexToDimensionPixelSize(typedValue.Data, Resources?.DisplayMetrics);
                }
            }

            return actionBarHeight;
        }
    }
}
