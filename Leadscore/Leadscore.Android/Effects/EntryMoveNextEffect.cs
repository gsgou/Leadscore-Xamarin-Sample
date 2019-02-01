using Leadscore.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(
    typeof(Leadscore.Droid.Effects.EntryMoveNextEffect), nameof(Leadscore.Effects.EntryMoveNextEffect))]

namespace Leadscore.Droid.Effects
{
    public class EntryMoveNextEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            // Check if the attached element is of the expected type and has the NextEntry
            // property set. If so, configure the keyboard to indicate there is another entry
            // in the form and the dismiss action to focus on the next entry
            if (base.Element is EntryMoveNextControl xfControl && xfControl.NextEntry != null)
            {
                var entry = (Android.Widget.EditText)Control;

                entry.ImeOptions = Android.Views.InputMethods.ImeAction.Next;
                entry.EditorAction += (sender, args) =>
                {
                    xfControl.OnNext();
                };
            }
        }

        // In base Effect OnDetached is declared as an abstract method. We have to implement the method in inherited class.
        // No implementation is provided by the OnDetached method because no cleanup is necessary.
        protected override void OnDetached()
        {

        }
    }
}