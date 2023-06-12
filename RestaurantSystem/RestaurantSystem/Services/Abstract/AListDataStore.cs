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
        public abstract Task RefreshListFromService();
        public abstract Task DeleteItemFromService(T item);
        public abstract Task UpdateItemInService(T item);
        public abstract Task AddItemToService(T item);

        public async Task UpdateItemAsync(T item)
        {
            await UpdateItemInService(item);
            await RefreshListFromService();
        }

        public async Task DeleteItemAsync(int id)
        {
            var oldItem = await Find(id);
            items.Remove(oldItem);
            await DeleteItemFromService(oldItem);
            await RefreshListFromService();
        }

        public async Task<T> GetItemAsync(int id)
        {
            return await Task.FromResult(await Find(id));
        }

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            await RefreshListFromService();
            return await Task.FromResult(items);
        }
    }
}