
using Android.App;
using Android.OS;

namespace ImageTextTranslatorApp.Droid.Activities
{

    [Activity(Label = "Take Picture", ParentActivity = typeof(MainActivity))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = ".MainActivity")]
    public class PictureActivity : Activity
    {
        // TODO: Specify the layout to inflace
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            
        }
        
        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnStop()
        {
            base.OnStop();
        }
        
    }
}