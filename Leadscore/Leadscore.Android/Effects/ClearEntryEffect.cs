using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using View = Android.Views.View;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Leadscore.Droid.Helpers;

[assembly: ResolutionGroupName("Leadscore.Effects")]
[assembly: ExportEffect(
    typeof(Leadscore.Droid.Effects.ClearEntryEffect), nameof(Leadscore.Effects.ClearEntryEffect))]

namespace Leadscore.Droid.Effects
{
    public class ClearEntryEffect : PlatformEffect
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

            Drawable clearDrawable = ApiSafe.GetDrawable(Resource.Mipmap.ic_clear);
            Drawable clearDrawablePressed = clearDrawable.GetConstantState().NewDrawable().Mutate();
            // Icon opacity: https://material.io/guidelines/style/icons.html
            clearDrawable.SetAlpha(54);
            clearDrawablePressed.SetAlpha(87);

            var stateListDrawable = new StateListDrawable();
            // Pressed State
            stateListDrawable.AddState(new int[] { global::Android.Resource.Attribute.StatePressed }, clearDrawablePressed);
            // Default State
            stateListDrawable.AddState(new int[] { }, clearDrawable);

            editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, stateListDrawable, null);
            editText.SetOnTouchListener(new OnClearEntryTouchListener());
        }
    }

    public class OnClearEntryTouchListener : Java.Lang.Object, View.IOnTouchListener
    {
        public bool OnTouch(View v, MotionEvent e)
        {
            EditText editText = (EditText)v;
            Drawable drawableRight = editText?.GetCompoundDrawables()[2];
            if (drawableRight != null && e.Action == MotionEventActions.Up)
            {
                int iconIntrinsicWidth = editText.GetCompoundDrawables()[2].IntrinsicWidth;
                if (e.RawX >= (editText.Right - iconIntrinsicWidth))
                {
                    editText.Text = string.Empty;

                    return true;
                }
            }

            return false;
        }
    }
}