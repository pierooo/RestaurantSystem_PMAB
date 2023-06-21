using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantSystem.Services.Abstract
{
    public abstract class AListDataStore<T> : ADataStore, IDataStore<T> where T : class
    {
        public List<T> items = new List<T>();
        public AListDataStore()
            : base()
        {
            RefreshListFromService();
        }

        public async Task AddItemAsync(T item)
        {
            await AddItemToService(item);
        }
        public abstract Task<T> Find(T item);
        public abstract Task<T> Find(int id);
        public abstract Task RefreshListFromService(int? originatorId = null);
        public abstract Task DeleteItemFromService(T item);
        public abstract Task UpdateItemInService(T item);
        public abstract Task AddItemToService(T item);

        public async Task UpdateItemAsync(T item, int? originatorId = null)
        {
            await UpdateItemInService(item);
            await RefreshListFromService(originatorId);
        }

        public async Task DeleteItemAsync(int id, int? originatorId = null)
        {
            var oldItem = await Find(id);
            items.Remove(oldItem);
            await DeleteItemFromService(oldItem);
            await RefreshListFromService(originatorId);
        }

        public async Task<T> GetItemAsync(int id)
        {
            return await Task.FromResult(await Find(id));
        }

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false, int? originatorId = null)
        {
            await RefreshListFromService(originatorId);
            return await Task.FromResult(items);
        }
    }
}