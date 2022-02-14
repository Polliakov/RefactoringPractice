using System;
using System.Linq;

namespace Polyakov.Search
{
    public class DataCache : IComparable<DataCache>
    {
        public int DataId { get; private set; }
        public float[] Key { get => keyField; set => keyField = value; }

        private float[] keyField = new float[3];

        public static DataCache[] CacheData(Data[] data)
        {
            var cache = new DataCache[data.Length];
            if (cache.Length == 0) return cache;

            for (int i = 0; i < cache.Length; i++)
            {
                cache[i] = new DataCache
                {
                    DataId = i,
                    Key = data[i].Key,
                };
            }
            return cache;
        }

        public int CompareTo(DataCache other)
        {
            if (other is null) return -1;

            for (int i = 0; i < Key.Length; i++)
            {
                if (Key[i] > other.Key[i])
                    return 1;

                else if (Key[i] < other.Key[i])
                    return -1;
            }
            return 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            if (obj is null)
                return false;

            var dataCach = obj as DataCache;
            if (dataCach is null)
                return false;
            else
                return Key.SequenceEqual(dataCach.Key);
        }
    }
}
