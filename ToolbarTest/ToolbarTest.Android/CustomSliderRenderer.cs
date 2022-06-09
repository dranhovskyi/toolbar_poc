using System;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Widget;
using ToolbarTest.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Slider), typeof(CustomSliderRenderer))]

namespace ToolbarTest.Droid
{
    public class CustomSliderRenderer : SliderRenderer
    {
        public CustomSliderRenderer(Context context)
            : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                System.Diagnostics.Debug.WriteLine(Control?.Parent);
                Control.BringToFront();
                Control.TranslationZ = float.MaxValue;
            }
        }
    }
}