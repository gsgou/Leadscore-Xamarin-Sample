using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V4.Content;

using Plugin.CurrentActivity;

namespace Leadscore.Droid.Helpers
{
    public static class ApiSafe
    {
        public static Drawable GetDrawable(int id)
        {
            Drawable drawable = null;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                drawable = ContextCompat.GetDrawable(CrossCurrentActivity.Current.Activity, id);
            }
            else
            {
                // This method was deprecated in API level 22.
                // Use getDrawable(int, Theme) instead.
#pragma warning disable 0618
                drawable = CrossCurrentActivity.Current.Activity.Resources.GetDrawable(id);
#pragma warning restore 0618
            }

            return drawable;
        }
    }
}