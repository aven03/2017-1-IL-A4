using System;
using System.Collections.Generic;
using System.Text;

namespace IntechCode.IntechCollection
{
    public interface IMyDictionary<TKey,TValue>
    {

        int Count { get; }

        /// <summary>
        /// Adds a key-value pair. The key must not already exist.
        /// </summary>
        /// <param name="key">The key to add.</param>
        /// <param name="value">The value to add.</param>
        void Add(TKey key, TValue value);

        bool Remove(TKey key);

        bool ContainsKey(TKey key);

        /// <summary>
        /// Gets the value associated to a key.
        /// When the key DOES NOT EXIST: <see cref="KeyNotFoundException"/>.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TValue this[TKey key] { get; }


        bool TryGetValue(TKey key, out TValue value);

    }
}
