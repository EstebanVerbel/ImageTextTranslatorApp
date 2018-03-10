using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using ImageTextTranslatorApp.Droid.Activities.Adapters;

namespace ImageTextTranslatorApp.Droid
{
    [Activity(Label = "@string/app_name",
        LaunchMode = LaunchMode.SingleInstance,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : BaseActivity
    {
        
        protected override int LayoutResource => Resource.Layout.activity_main;

        ViewPager pager;
        TabsAdapter adapter;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            adapter = new TabsAdapter(this, SupportFragmentManager);
            pager = FindViewById<ViewPager>(Resource.Id.viewpager);
            var tabs = FindViewById<TabLayout>(Resource.Id.tabs);
            pager.Adapter = adapter;
            tabs.SetupWithViewPager(pager);
            pager.OffscreenPageLimit = 3;
            
            pager.PageSelected += (sender, args) =>
            {
                var fragment = adapter.InstantiateItem(pager, args.Position) as IFragmentVisible;

                fragment?.BecameVisibleAsync();
            };
            
            // add event handler for menu item clickS. For now to select target language
            Toolbar.MenuItemClick += Toolbar_MenuItemClick;
            
            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(false);
        }

        private void Toolbar_MenuItemClick(object sender, Android.Support.V7.Widget.Toolbar.MenuItemClickEventArgs e)
        {
            switch (e.Item.ItemId)
            {
                case Resource.Id.languageSpanishItem:
                    break;
                case Resource.Id.languageFrenchItem:
                    break;
                case Resource.Id.languageCantoneseTraditionalItem:
                    break;
                case Resource.Id.languageChineseSimplifiedItem:
                    break;
                case Resource.Id.languageChineseTraditionalItem:
                    break;
                case Resource.Id.languageGermanItem:
                    break;
                case Resource.Id.languageItalianItem:
                    break;
                case Resource.Id.languageKoreanItem:
                    break;
                case Resource.Id.languageRussianItem:
                    break;
                default:
                    break;
            }
        }
        
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        
    }
}


