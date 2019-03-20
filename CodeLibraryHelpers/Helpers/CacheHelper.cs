using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Caching;


namespace CodeLibraryHelpers.Helpers
{
  public static class CacheHelper
  {

    static CacheItemPolicy cacheItemPolicy;    

    public static void AddToCache(string cacheKey, object itemToAdd)
    {
      CacheItem cacheItem = new CacheItem(cacheKey);
      var item            = itemToAdd;
      cacheItem.Value     = item;
      cacheItemPolicy     = cacheItemPolicy ?? GetCachingPolicy();
      ObjectCache cache   = MemoryCache.Default;
      cache.Set(cacheItem, cacheItemPolicy);
    }

    public static object GetFromCache(string cacheKey)
    {
      ObjectCache cache = MemoryCache.Default;      
      return cache[cacheKey];

    }
    public static CacheItemPolicy GetCachingPolicy()
    {
      List<int> cachingTimeSpanPeriodIntList = new List<int>();
      string[] cachingTimeSpanPeriodStringArray = ConfigurationManager.AppSettings["CachingTimespanHoursMinutesSeconds"].ToString().Split(',');
      cachingTimeSpanPeriodStringArray.ToList().ForEach(e => cachingTimeSpanPeriodIntList.Add(int.Parse(e)));      
      CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
      cacheItemPolicy.AbsoluteExpiration = DateTime.Now.Add(new TimeSpan(cachingTimeSpanPeriodIntList[0], cachingTimeSpanPeriodIntList[1], cachingTimeSpanPeriodIntList[2]));

      return cacheItemPolicy;
    }    
  }
}
