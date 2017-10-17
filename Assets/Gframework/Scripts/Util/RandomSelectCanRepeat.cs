using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class RandomSelectCanRepeatExtension  {

    public static IEnumerable<T> RandomSelectCanRepeat<T>(this IEnumerable<T> Source, int selectNum)
    {
        var sourceList=new List<T>();
        foreach (var data in Source)
        {
            sourceList.Add(data);
        }

        var result=new List<T>();
        for (int i = 0; i < selectNum; i++)
        {
            var index = Random.Range(0, sourceList.Count);
            result.Add(sourceList[index]);
        }
        return result;
    }
}
