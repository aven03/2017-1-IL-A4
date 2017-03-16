using System;
using System.Collections.Generic;
using System.Text;

namespace IntechCode.IntechCollection
{
    public interface IMyReadOnlyCollection<out T> : IMyEnumerable<T>
    {
        int Count { get; }
    }
}
