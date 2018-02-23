using ImageTextTranslatorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageTextTranslatorApp.Services
{
    public class DataStore : IDataStore<Picture>
    {

        private Picture _picture;

        public async Task<bool> AddItemAsync(Picture item)
        {
            _picture = item;
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Picture item)
        {
            _picture = null;
            return await Task.FromResult(true);
        }

        public  async Task<Picture> GetItemAsync(string id)
        {
            return await Task.FromResult(_picture);
        }

        public async Task<IEnumerable<Picture>> GetItemsAsync(bool forceRefresh = false)
        {
            IEnumerable<Picture> result = new List<Picture> { _picture };
            return await Task.FromResult(result);
        }
        
        public async Task<bool> PullLatestAsync()
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> SyncAsync()
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Picture item)
        {
            _picture = item;
            return await Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
        }
    }
}
