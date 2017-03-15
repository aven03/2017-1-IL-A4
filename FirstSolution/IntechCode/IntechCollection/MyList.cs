using System;

namespace IntechCode.IntechCollection
{
    public class MyList<T> : IMyList<T>
    {
        public T this[int index] 
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public int Count => throw new NotImplementedException();

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    }
}
