using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomSelectNoRepeatExtension
{

    public static IEnumerable<T> RandomSelectNoRepeat<T>(this IEnumerable<T> Source,int selectNum)
    {
        var sourceList = new List<T>();
        foreach (var data in Source)
        {
            sourceList.Add(data);
        }

        var result = new List<T>();
        for (int i = 0; i < selectNum; i++)
        {
            var index = Random.Range(0, sourceList.Count);
            result.Add(sourceList[index]);
            sourceList.RemoveAt(index);
        }
        return result;
    }
}
