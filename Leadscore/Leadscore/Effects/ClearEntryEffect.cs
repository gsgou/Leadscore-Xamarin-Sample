using Xamarin.Forms;

namespace Leadscore.Effects
{
    // This string is used to route the effect to the relevant platform specific implementation.
    public class ClearEntryEffect : RoutingEffect
    {
        public ClearEntryEffect()
            : base(typeof(ClearEntryEffect).FullName)
        {

        }
    }
}