using System;
using System.Runtime.Caching;

namespace Utilities.Caching
{
    /// <summary>
    /// Requires Import of: System.Runtime.Caching.MemoryCache
    /// MemoryCacher is a wrapper class around the System.Runtime.Caching.MemoryCache class.
    /// </summary>
    public class MemoryCacher
    {
        /// <summary>
        /// Gets the value, given the key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetValue(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Get(key);
        }

        /// <summary>
        /// Adds a value to the cache.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="absExpiration"></param>
        /// <returns></returns>
        public bool Add(string key, object value)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(key, value, DateTimeOffset.UtcNow.AddMonths(1));
        }
        public bool Add(string key, object value, DateTimeOffset absExpiration)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(key, value, absExpiration);
        }

        /// <summary>
        /// Deletes a value from the cache.
        /// </summary>
        /// <param name="key"></param>
        public void Delete(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(key))
            {
                memoryCache.Remove(key);
            }
        }

    }
}
