using System;

using UIKit;

using Leadscore.iOS.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(Leadscore.iOS.Effects.ShowHidePassEffect), nameof(Leadscore.Effects.ShowHidePassEffect))]
namespace Leadscore.iOS.Effects
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
            UITextField updatedEntry;
            if (Control is UITextField)
            {
                updatedEntry = (UITextField)Control;
            }
            else
            {
                return;
            }

            UIImage visibilityImage = UIImage.FromBundle("ic_visibility");
            UIImage visibilityOffImage = UIImage.FromBundle("ic_visibility_off");

            UIButton buttonRect = UIButton.FromType(UIButtonType.Custom);
            buttonRect.SetImage(updatedEntry.SecureTextEntry ? visibilityOffImage.WithAlpha((nfloat)0.54) : visibilityImage.WithAlpha((nfloat)0.54), UIControlState.Normal);
            buttonRect.SetImage(updatedEntry.SecureTextEntry ? visibilityOffImage.WithAlpha((nfloat)0.87) : visibilityImage.WithAlpha((nfloat)0.87), UIControlState.Highlighted);

            buttonRect.TouchUpInside += (object sender, EventArgs e1) =>
            {
                if (updatedEntry.SecureTextEntry)
                {
                    updatedEntry.SecureTextEntry = false;
                    buttonRect.SetImage(visibilityImage.WithAlpha((nfloat)0.54), UIControlState.Normal);
                    buttonRect.SetImage(visibilityImage.WithAlpha((nfloat)0.87), UIControlState.Highlighted);
                }
                else
                {
                    updatedEntry.SecureTextEntry = true;
                    buttonRect.SetImage(visibilityOffImage.WithAlpha((nfloat)0.54), UIControlState.Normal);
                    buttonRect.SetImage(visibilityOffImage.WithAlpha((nfloat)0.87), UIControlState.Highlighted);
                }
            };

            updatedEntry.ShouldChangeCharacters += (textField, range, replacementString) =>
            {
                string text = updatedEntry.Text;
                var result = text.Substring(0, (int)range.Location) + replacementString + text.Substring((int)range.Location + (int)range.Length);
                updatedEntry.Text = result;
                return false;
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