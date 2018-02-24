using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using ImageTextTranslatorApp.Models;
using ImageTextTranslatorApp.ViewModels;

namespace ImageTextTranslatorApp.Droid
{
    internal class TranslateFragment : Android.Support.V4.App.Fragment, IFragmentVisible
    {
        #region -- Properties --
        
        public static TranslateFragment NewInstance() => new TranslateFragment { Arguments = new Bundle() };
        
        public TranslateTextViewModel ViewModel { get; set; }

        #endregion

        #region -- Members --

        private Button _translateButton;
        private TextInputEditText _fromTextInputEditField;
        private TextInputEditText _toTextInputEditField;

        #endregion

        #region -- Overrides --

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_translate, container, false);
            ViewModel = new TranslateTextViewModel();
            _translateButton = view.FindViewById<Button>(Resource.Id.translateButton);
            _fromTextInputEditField = view.FindViewById<TextInputEditText>(Resource.Id.fromTextInputEditText);
            _toTextInputEditField = view.FindViewById<TextInputEditText>(Resource.Id.toTextInputEditText);

            return view;
        }

        public override void OnStart()
        {
            base.OnStart();

            // TODO: Add translate button click event handler
        }

        public override void OnStop()
        {
            base.OnStop();

            // TODO: Remove translate button click event handler
        }

        #endregion

        #region -- Event Handlers --



        #endregion

        #region -- IFragmentVisible --
        
        public async Task BecameVisibleAsync()
        {
            _fromTextInputEditField.Text = await ViewModel.GetImageText();
        }

        #endregion

    }
}