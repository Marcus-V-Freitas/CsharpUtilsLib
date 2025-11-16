using Timer = System.Timers.Timer;

namespace CsharpUtilsLib.Collection.Types
{
    public sealed class CacheCollection<TKey, TValue> : IDisposable
        where TKey : notnull
    {
        private readonly Dictionary<TKey, CacheItem<TValue>> _cache = [];
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
            _cache.AddOrChangeValue(key, new CacheItem<TValue>(value, DateTime.UtcNow));
            return true;
        }

        public TValue GetFromCache(TKey key)
        {
            if (_cache.TryGetValue(key, out CacheItem<TValue> cacheItem))
            {
                if (DateTime.UtcNow - cacheItem.CreationTime <= _cacheDuration)
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

            DateTime now = DateTime.UtcNow;

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

        private struct CacheItem<T>(T value, DateTime creationTime)
        {
            public T Value { get; private set; } = value;
            public DateTime CreationTime { get; private set; } = creationTime;

            public void Reset(DateTime creationDate)
            {
                CreationTime = creationDate;
            }
        }
    }
}