using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantSystem.Services.Abstract
{
    public interface IDataStore<T>
    {
        Task AddItemAsync(T item);
        Task UpdateItemAsync(T item, int? originatorId = null);
        Task DeleteItemAsync(int id, int? originatorId = null);
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false, int? originatorId = null);
    }
}
