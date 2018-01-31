using System;

using ImageTextTranslatorApp.Models;

namespace ImageTextTranslatorApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            if (item != null)
            {
                Title = item.Text;
                Item = item;
            }
        }
    }
}
