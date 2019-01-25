using System;

using CoreGraphics;
using UIKit;

namespace Leadscore.iOS.Extensions
{
    static class ImageExtensions
    {
        public static UIImage WithAlpha(this UIImage image, nfloat alpha)
        {
            if (image == null)
            {
                return null;
            }

            // Use UIGraphicsBeginImageContextWithOptions to take the scale into consideration
            UIGraphics.BeginImageContextWithOptions(image.Size, false, 0);
            CGContext context = UIGraphics.GetCurrentContext();

            CGRect rect = new CGRect(0, 0, image.Size.Width, image.Size.Height);

            // Flip the context because UIKit coordinate system is upside down to Quartz coordinate system
            context.ScaleCTM(1, -1);
            context.TranslateCTM(0, -rect.Size.Height);

            context.SetBlendMode(CGBlendMode.Multiply);
            context.SetAlpha(alpha);

            context.DrawImage(rect, image.CGImage);

            UIImage imageFromCurrentImageContext = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            return imageFromCurrentImageContext;
        }
    }
}