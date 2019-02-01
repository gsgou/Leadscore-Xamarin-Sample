using CoreGraphics;
using UIKit;

using Leadscore.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(
    typeof(Leadscore.iOS.Effects.EntryMoveNextEffect), nameof(Leadscore.Effects.EntryMoveNextEffect))]

namespace Leadscore.iOS.Effects
{
    public class EntryMoveNextEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var entry = (UITextField)Control;

            // Change return key to Done key
            entry.ReturnKeyType = UIReturnKeyType.Done;

            // Add the "done" button to the toolbar and dismiss
            // the keyboard when it may not have a return key
            if (entry.KeyboardType == UIKeyboardType.DecimalPad ||
                entry.KeyboardType == UIKeyboardType.NumberPad)
            {
                entry.InputAccessoryView = BuildDismiss();
            }

            // Check if the attached element is of the expected type and has the NextEntry
            // property set. If so, configure the keyboard to indicate there is another entry
            // in the form and the dismiss action to focus on the next entry
            if (base.Element is EntryMoveNextControl xfControl && xfControl.NextEntry != null)
            {
                entry.ReturnKeyType = UIReturnKeyType.Next;
            }
        }

        // In base Effect OnDetached is declared as an abstract method. We have to implement the method in inherited class.
        // No implementation is provided by the OnDetached method because no cleanup is necessary.
        protected override void OnDetached()
        {

        }

        private UIToolbar BuildDismiss()
        {
            var toolbar = new UIToolbar(new CGRect(0.0f, 0.0f, Control.Frame.Size.Width, 44.0f));

            // Set default state of buttonAction/appearance
            UIBarButtonItem buttonAction = new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate { Control.ResignFirstResponder(); });

            // If we have a next element, swap out the default state for "Next"
            if (base.Element is EntryMoveNextControl xfControl && xfControl.NextEntry != null)
            {
                buttonAction = new UIBarButtonItem("Next", UIBarButtonItemStyle.Plain, delegate
                {
                    xfControl.OnNext();
                });
            }

            toolbar.Items = new[]
            {
                new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
                buttonAction,
            };

            return toolbar;
        }
    }
}