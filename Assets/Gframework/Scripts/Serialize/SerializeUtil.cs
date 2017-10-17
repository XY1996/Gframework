using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class SerializeUtil  {

    /// <summary>
    /// Get AllSerializeFields Name
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static string[] GetAllSerializeFieldsName(Type type)
    {
        return type.GetProperties().Select(p=>p.Name).ToArray();
    }
}
