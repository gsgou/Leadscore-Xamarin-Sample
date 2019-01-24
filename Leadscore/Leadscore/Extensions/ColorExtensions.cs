using Xamarin.Forms;

namespace Leadscore.Extensions
{
    public static class ColorExtensions
    {
        #region Material Colors

        // Background Colors
        public static readonly Color BackgroundColorLight = Color.FromHex("#FAFAFA");

        // Dividers Color
        public static readonly Color TextColorDarkDividers = Color.FromRgba(0, 0, 0, 0.12);

        // Text Colors
        // Dark
        public static readonly Color TextColorDarkPrimary = Color.FromRgba(0, 0, 0, 0.87);
        // Light
        public static readonly Color TextColorLightPrimary = Color.FromHex("#FFFFFF");
        // Error
        // Color: 100% red (A400)
        public static readonly Color TextColorError = Color.FromHex("#FF1744");

        #endregion

        #region Leadscore Colors

        public static readonly Color LeadscorePrimary = Color.FromHex("#1262BE");

        #endregion
    }
}