using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class Pool<T> where T : class
    {
        public Dictionary<T, bool> _items;

        public Pool(IEnumerable<T> items)
        {
            _items = items.ToDictionary((x) => x, (x) => false);
        }

        public T Get()
        {
            var item = _items.FirstOrDefault(pair => !pair.Value).Key;
            if (item == null)
                throw new ArgumentOutOfRangeException($"Can't find free item of type {typeof(T)} in pool");

            _items[item] = true;
            return item;
        }

        public void Return(T item)
        {
            _items[item] = false;
        }
    }
}