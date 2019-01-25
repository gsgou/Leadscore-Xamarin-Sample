using System;

using Android.App;
using Android.OS;
using Android.Runtime;

using Plugin.CurrentActivity;

namespace Leadscore.Droid
{
    // Java Debug Wire Protocol (JDWP) allows tools such as ADB to communicate with a JVM. 
    // JDWP is important during development, it should be disabled in published application.
#if DEBUG
    [Application(Debuggable = true)]
#else
    [Application(Debuggable=false)]
#endif

    // Google introduced with the release of Ice Cream Sandwich (API 14) ActivityLifecycleCallbacks. With it we can figure out the current activity. 
    // It must be implemented on “Application” class and call RegisterActivityLifecycleCallbacks. Needed from PermissionsPlugin.
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();

            RegisterActivityLifecycleCallbacks(this);
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {

        }

        public void OnActivityPaused(Activity activity)
        {

        }

        public void OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {

        }

        public void OnActivityStarted(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityStopped(Activity activity)
        {

        }
    }
}