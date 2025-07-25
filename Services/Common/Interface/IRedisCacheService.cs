﻿namespace Cimo.Services.Common.Interface
{
    public interface IRedisCacheService
    {
        Task SetAsync<T>(string key, T value, double? Time = null);
        Task<T?> GetAsync<T>(string key);
        Task RemoveAsync(string key);
    }
}
