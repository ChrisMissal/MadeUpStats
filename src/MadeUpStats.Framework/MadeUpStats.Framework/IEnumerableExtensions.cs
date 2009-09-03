using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MadeUpStats.Framework
{
    public static class IEnumerableExtensions
    {
        [DebuggerStepThrough]
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> processor)
        {
            foreach (var item in items)
                processor(item);
        }
    }
}