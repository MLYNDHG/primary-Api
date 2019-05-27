using System;
using Microsoft.Extensions.Caching.Memory;

namespace RayPI.Token
{
    /// <summary>
    /// 该类是一个系统扩展类，用于继承我们常用的对MemoryCache的操作
    /// </summary>
    public class RayPIMemoryCache
    {
        /// <summary>
        /// MemoryCache对象   需要添加NuGet包  搜索Memory即可
        /// </summary>
        public static MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        /// <summary>
        /// 验证缓存项是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Exists(string key) {
            if (key==null) {
                throw new ArgumentNullException(nameof(key));
            }
            object cached;
            return _cache.TryGetValue(key,out cached);
        }
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Get(string key) {
            if (key==null) {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.Get(key);
        }
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="expiresSliding">滑动过期时常（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <param name="expiressAbsolute">绝对过期时间</param>
        /// <returns></returns>
        public static bool AddMemoryCache(string key,object value, TimeSpan expiresSliding,TimeSpan expiressAbsolute) {
            if (key==null) {
                throw new ArgumentNullException(nameof(key));
            }
            if (value==null) {
                throw new ArgumentNullException(nameof(value));
            }
            _cache.Set(key,value,new MemoryCacheEntryOptions().SetSlidingExpiration(expiresSliding).SetAbsoluteExpiration(expiressAbsolute));
            return Exists(key);
        }
    }
}
