using Android.Graphics.Drawables;
using Android.Text.Method;
using Android.Views;
using Android.Widget;
using View = Android.Views.View;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Leadscore.Droid.Helpers;

[assembly: ExportEffect(typeof(Leadscore.Droid.Effects.ShowHidePassEffect), nameof(Leadscore.Effects.ShowHidePassEffect))]
namespace Leadscore.Droid.Effects
{
    public class ShowHidePassEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            ConfigureControl();
        }

        // In base Effect OnDetached is declared as an abstract method. We have to implement the method in inherited class.
        // No implementation is provided by the OnDetached method because no cleanup is necessary.
        protected override void OnDetached()
        {

        }

        void ConfigureControl()
        {
            EditText editText;
            if (Control is EditText)
            {
                editText = (EditText)Control;
            }
            else
            {
                return;
            }

            Drawable visibilityOffDrawable = ApiSafe.GetDrawable(Resource.Mipmap.ic_visibility_off);
            // Icon opacity: https://material.io/guidelines/style/icons.html
            visibilityOffDrawable.SetAlpha(54);
            // IntrinsicWidth/Height provides the default height or width of that drawable
            // https://developer.android.com/reference/android/graphics/drawable/Drawable.html#getIntrinsicHeight()
            editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, visibilityOffDrawable, null);

            editText.TransformationMethod = PasswordTransformationMethod.Instance;
            editText.SetOnTouchListener(new OnShowHidePassTouchListener());
        }
    }

    public class OnShowHidePassTouchListener : Java.Lang.Object, View.IOnTouchListener
    {
        Drawable visibilityDrawable, visibilityOffDrawable;

        public OnShowHidePassTouchListener()
        {
            visibilityDrawable = ApiSafe.GetDrawable(Resource.Mipmap.ic_visibility);
            visibilityDrawable.SetAlpha(54);

            visibilityOffDrawable = ApiSafe.GetDrawable(Resource.Mipmap.ic_visibility_off);
            visibilityOffDrawable.SetAlpha(54);
        }

        public bool OnTouch(View v, MotionEvent e)
        {
            if (v is EditText && e.Action == MotionEventActions.Up)
            {
                EditText editText = (EditText)v;
                Drawable drawableRight = editText?.GetCompoundDrawables()[2];
                if (drawableRight != null && e.Action == MotionEventActions.Up)
                {
                    int iconIntrinsicWidth = editText.GetCompoundDrawables()[2].IntrinsicWidth;
                    if (e.RawX >= (editText.Right - iconIntrinsicWidth))
                    {
                        if (editText.TransformationMethod == null)
                        {
                            editText.TransformationMethod = PasswordTransformationMethod.Instance;
                            editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, visibilityOffDrawable, null);
                        }
                        else
                        {
                            editText.TransformationMethod = null;
                            editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, visibilityDrawable, null);
                        }

                        return true;
                    }
                }
            }

            return false;
        }
    }
}