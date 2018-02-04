using System;

using Android.App;
using Android.OS;
using Android.Runtime;
using ImageTextTranslatorApp.Droid.Services;
using ImageTextTranslatorApp.Helpers;
using ImageTextTranslatorApp.Models.Services;
using Plugin.CurrentActivity;

namespace ImageTextTranslatorApp.Droid
{
	//You can specify additional application information in this attribute
	[Application]
	public class MainApplication : Application, Application.IActivityLifecycleCallbacks
	{
		public MainApplication(IntPtr handle, JniHandleOwnership transer)
		  : base(handle, transer)
		{
		}

		public override void OnCreate()
		{
			base.OnCreate();
			RegisterActivityLifecycleCallbacks(this);

            // register take picture class
            ServiceLocator.Instance.Register<ITakePicture, TakePicture>();
            
			App.Initialize();
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