using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ListComparer<T> : IEqualityComparer<List<T>>
{
    public bool Equals(List<T> x, List<T> y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x == null || y == null) return false;

        // SequenceEqual checks if items match and are in the same order
        x.Sort((a,b) => a.GetHashCode().CompareTo(b.GetHashCode()));
        return x.SequenceEqual(y);
    }

    public int GetHashCode(List<T> obj)
    {
        if (obj == null) return 0;
        
        var hash = new HashCode();
        foreach (var item in obj)
        {
            hash.Add(item);
        }
        return hash.ToHashCode();
    }
}
