using Android.OS;
using Android.Views;

namespace ImageTextTranslatorApp.Droid.Fragments
{
    public class PictureFragment : Android.Support.V4.App.Fragment, IFragmentVisible
    {
        // new instance static property
        public static PictureFragment NewInstance() => new PictureFragment { Arguments = new Bundle() };    

        // View Model Property


        #region -- Overrides --

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);  
        }
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return base.OnCreateView(inflater, container, savedInstanceState);

            // TODO: Inflate button to take picture
        }
        
        public override void OnStart()
        {
            base.OnStart();
            // TODO: Add click event handler to button
        }
        
        public override void OnStop()
        {
            base.OnStop();
            // TODO: Remove event handler from button
        }

        #endregion

        #region -- IBecameVisible --

        public void BecameVisible()
        {
            
        }

        #endregion

        // event handlers?
    }
}