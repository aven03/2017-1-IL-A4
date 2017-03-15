using System;

namespace IntechCode.IntechCollection
{
    public interface IMyList<T>
    {
        void Add( T item );

        void RemoveAt( int index );

        void Insert( int index, T item );

        int Count { get; }

        int IndexOf( T item );

        T this[ int index ] { get; set; }
    }

}
