using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace ERP.V7.WebPMS.Services.Common
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<CacheService> _logger;
        private static readonly ConcurrentDictionary<string, byte> _keys = new();

        public CacheService(IMemoryCache memoryCache, ILogger<CacheService> logger)
        {
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public async Task<T> GetOrCreateAsync<T>(
            string key, 
            Func<Task<T>> factory, 
            TimeSpan? slidingExpiration = null, 
            TimeSpan? absoluteExpiration = null, 
            bool forceRefresh = false)
        {
            if (!forceRefresh && _memoryCache.TryGetValue(key, out T? cachedValue) && cachedValue != null)
            {
                _logger.LogDebug("Cache HIT for key: {CacheKey}", key);
                return cachedValue;
            }

            _logger.LogDebug("Cache MISS (or force refresh) for key: {CacheKey}", key);
            var result = await factory();
            if (result != null)
            {
                var options = new MemoryCacheEntryOptions
                {
                    SlidingExpiration = slidingExpiration ?? TimeSpan.FromMinutes(10),
                    AbsoluteExpirationRelativeToNow = absoluteExpiration ?? TimeSpan.FromHours(1)
                };

                _memoryCache.Set(key, result, options);
                _keys.TryAdd(key, 0);
            }

            return result;
        }

        public bool TryGetValue<T>(string key, out T? value)
        {
            return _memoryCache.TryGetValue(key, out value);
        }

        public void Set<T>(string key, T value, TimeSpan? slidingExpiration = null, TimeSpan? absoluteExpiration = null)
        {
            if (value == null) return;

            var options = new MemoryCacheEntryOptions
            {
                SlidingExpiration = slidingExpiration ?? TimeSpan.FromMinutes(10),
                AbsoluteExpirationRelativeToNow = absoluteExpiration ?? TimeSpan.FromHours(1)
            };

            _memoryCache.Set(key, value, options);
            _keys.TryAdd(key, 0);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
            _keys.TryRemove(key, out _);
            _logger.LogInformation("Removed cache key: {CacheKey}", key);
        }

        public void RemoveByPrefix(string prefix)
        {
            int count = 0;
            foreach (var key in _keys.Keys)
            {
                if (key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    _memoryCache.Remove(key);
                    _keys.TryRemove(key, out _);
                    count++;
                }
            }
            _logger.LogInformation("Removed {Count} cache entries with prefix: {Prefix}", count, prefix);
        }

        public void Clear()
        {
            int count = _keys.Count;
            foreach (var key in _keys.Keys)
            {
                _memoryCache.Remove(key);
                _keys.TryRemove(key, out _);
            }
            _logger.LogInformation("Cleared all {Count} cache entries", count);
        }
    }
}
