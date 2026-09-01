using System;
using System.Threading.Tasks;

namespace ERP.V7.WebPMS.Services.Common
{
    public interface ICacheService
    {
        Task<T> GetOrCreateAsync<T>(
            string key, 
            Func<Task<T>> factory, 
            TimeSpan? slidingExpiration = null, 
            TimeSpan? absoluteExpiration = null, 
            bool forceRefresh = false);

        bool TryGetValue<T>(string key, out T? value);
        void Set<T>(string key, T value, TimeSpan? slidingExpiration = null, TimeSpan? absoluteExpiration = null);
        void Remove(string key);
        void RemoveByPrefix(string prefix);
        void Clear();
    }
}
