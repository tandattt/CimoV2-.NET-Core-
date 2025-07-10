using Cimo.Services.Interface;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Cimo.Services.Interface
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task SetAsync<T>(string key, T value, double? Time = null)
        {
            var jsonData = JsonSerializer.Serialize(value);
            TimeSpan? expireTime = Time.HasValue ? TimeSpan.FromMinutes(Time.Value) : null;
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expireTime ?? TimeSpan.FromMinutes(5)
            };

            await _cache.SetStringAsync(key, jsonData, options);
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var jsonData = await _cache.GetStringAsync(key);
            if (string.IsNullOrEmpty(jsonData)) return default;

            return JsonSerializer.Deserialize<T>(jsonData);
        }

        public async Task RemoveAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }
    }
}
