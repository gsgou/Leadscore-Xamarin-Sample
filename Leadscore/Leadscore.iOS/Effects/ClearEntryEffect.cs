using System;

using UIKit;

using Leadscore.iOS.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Leadscore.Effects")]
[assembly: ExportEffect(typeof(Leadscore.iOS.Effects.ClearEntryEffect), nameof(Leadscore.Effects.ClearEntryEffect))]
namespace Leadscore.iOS.Effects
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
            UITextField updatedEntry;
            if (Control is UITextField)
            {
                updatedEntry = (UITextField)Control;
            }
            else
            {
                return;
            }

            updatedEntry.ClearButtonMode = UITextFieldViewMode.Never;

            UIImage clearImage = UIImage.FromFile("ic_clear");

            UIButton buttonRect = UIButton.FromType(UIButtonType.Custom);
            buttonRect.SetImage(clearImage.WithAlpha((nfloat)0.54), UIControlState.Normal);
            buttonRect.SetImage(clearImage.WithAlpha((nfloat)0.87), UIControlState.Highlighted);

            buttonRect.TouchUpInside += (object sender, EventArgs e1) =>
            {
                updatedEntry.Text = string.Empty;
            };

            updatedEntry.ShouldClear += (textField) =>
            {
                if (updatedEntry.Text.Length == 0)
                {
                    return false;
                }

                return true;
            };

            buttonRect.Frame = new CoreGraphics.CGRect(4.0d, 0.0d, 24.0d, 24.0d);
            buttonRect.ContentMode = UIViewContentMode.Center;

            UIView paddingViewRight = new UIView(new CoreGraphics.CGRect(0.0d, 0.0d, 27.0d, 24.0d));
            paddingViewRight.Add(buttonRect);
            paddingViewRight.ContentMode = UIViewContentMode.BottomRight;

            updatedEntry.RightView = paddingViewRight;
            updatedEntry.RightViewMode = UITextFieldViewMode.Always;
            updatedEntry.TextAlignment = UITextAlignment.Left;
        }
    }
}