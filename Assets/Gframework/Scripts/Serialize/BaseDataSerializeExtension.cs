using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Gframework;
using UnityEngine;

public static class BaseDataSerializeExtension {


    /// <summary>
    /// csv, json 
    /// </summary>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static string ToString(this BaseData data,string provider)
    {
        switch (provider)
        {
            case "csv":
                return data.ToString(new CSVSerializeProvider());
            case "json":
                return data.ToString(new JSONSerializeProvider());
            default:
                return data.ToString(new JSONSerializeProvider());
        }
    }
    /// <summary>
    /// To String
    /// </summary>
    /// <param name="data"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static string ToString(this BaseData data, ISerializeProvider provider)
    {
        return provider.ObjectToString(data);
    }

}
