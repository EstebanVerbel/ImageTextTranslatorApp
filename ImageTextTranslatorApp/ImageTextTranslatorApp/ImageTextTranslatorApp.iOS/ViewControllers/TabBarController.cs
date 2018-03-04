using System;
using UIKit;

namespace ImageTextTranslatorApp.iOS
{
    public partial class TabBarController : UITabBarController
    {
        public TabBarController (IntPtr handle) : base (handle)
        {
            TabBar.Items[0].Title = "Picture";
            TabBar.Items[1].Title = "About";
        }
    }
}