using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ShuffleExtension
{

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> Source)
    {
        return Source.OrderBy(x => Guid.NewGuid());
    }
}
