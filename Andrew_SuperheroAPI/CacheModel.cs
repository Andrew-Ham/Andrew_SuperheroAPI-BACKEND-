using Microsoft.Extensions.Caching.Memory;


namespace Andrew_SuperheroAPI
{
    public static class CacheModel
    {
        private static IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());
        

        public static void Add(string cachekey, int value)
        {
            var cacheExpiryOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(20),
            };

            _memoryCache.Set(cachekey, value, cacheExpiryOptions);
        }

        public static int Get(string cacheKey)
        {
            var result = _memoryCache.Get(cacheKey);
            return Convert.ToInt32(result);
        }

        public static void Delete(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
        }
    }
}
