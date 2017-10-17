using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class CSVSerializeProvider : ISerializeProvider {


    public string ObjectToString(object o)
    {
        string result = "";
        List<string> data=new List<string>();
        Type t = o.GetType();

        foreach (PropertyInfo pi in t.GetProperties())
        {
            object value1 = pi.GetValue(o, null);
            string name = pi.Name;
            if (value1 == null)
            {
                data.Add("null");
            }
            else if (value1 is DateTime|| value1.GetType() == typeof(DateTime?))
            {
                data.Add(((DateTime)value1).ToString("yyyy/MM/dd HH:mm:ss:fff"));
            }
            else
            {
                data.Add(value1.ToString());
            }
        }
        if (data.Any())
            result = string.Join(",", data);
        return result;
    }
}
