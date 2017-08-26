using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Thread Safe Normal Singleton
/// </summary>
public class Singleton<T> where T: new()
{
    protected Singleton()
    {

    }
    private static readonly object _object = new object();

    private static T instance=default(T);
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (_object)
                {
                    if (instance == null)
                    {
                        instance = new T();
                    }
                }
            }
            return instance;
        }
    }
}
