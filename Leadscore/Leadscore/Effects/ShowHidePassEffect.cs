using Xamarin.Forms;

namespace Leadscore.Effects
{
    // This string is used to route the effect to the relevant platform specific implementation.
    public class ShowHidePassEffect : RoutingEffect
    {
        public ShowHidePassEffect()
            : base(typeof(ShowHidePassEffect).FullName)
        {

        }
    }
}