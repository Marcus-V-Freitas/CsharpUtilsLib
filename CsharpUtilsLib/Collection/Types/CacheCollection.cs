using Timer = System.Timers.Timer;

namespace CsharpUtilsLib.Collection.Types
{
    public sealed class CacheCollection<TKey, TValue> : IDisposable
    {
        private readonly Dictionary<TKey, CacheItem<TValue>> _cache = new();
        private readonly TimeSpan _cacheDuration;
        private readonly Timer _cacheTimer;

        public CacheCollection(TimeSpan cacheDuration)
        {
            _cacheDuration = cacheDuration;
            _cacheTimer = new Timer(cacheDuration.TotalMilliseconds);
            _cacheTimer.Elapsed += CacheTimerElapsed!;
            _cacheTimer.Start();
        }

        public bool AddOrChangeToCache(TKey key, TValue value)
        {
            _cache.AddOrChangeValue(key, new CacheItem<TValue>(value, DateTime.Now));
            return true;
        }

        public TValue GetFromCache(TKey key)
        {
            if (_cache.TryGetValue(key, out CacheItem<TValue> cacheItem))
            {
                if (DateTime.Now - cacheItem.CreationTime <= _cacheDuration)
                {
                    return cacheItem.Value;
                }
                else
                {
                    _cache.Remove(key);
                }
            }

            return default!;
        }

        public void Reset()
        {
            _cacheTimer.Stop();

            DateTime now = DateTime.Now;

            foreach (var value in _cache.Values)
            {
                value.Reset(now);
            }

            _cacheTimer.Start();
        }

        public void ClearCache()
        {
            _cache.Clear();
        }

        public void Dispose()
        {
            _cacheTimer?.Dispose();
        }

        private void CacheTimerElapsed(object sender, ElapsedEventArgs e)
        {
            ClearCache();
            Reset();
        }

        private struct CacheItem<T>
        {
            public T Value { get; private set; }
            public DateTime CreationTime { get; private set; }

            public CacheItem(T value, DateTime creationTime)
            {
                Value = value;
                CreationTime = creationTime;
            }

            public void Reset(DateTime creationDate)
            {
                CreationTime = creationDate;
            }
        }
    }
}
