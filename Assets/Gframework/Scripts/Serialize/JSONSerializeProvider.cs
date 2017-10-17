using System.Collections;
using System.Collections.Generic;
using Gframework.Core.Util;
using UnityEngine;

public class JSONSerializeProvider : ISerializeProvider {

    public string ObjectToString(object o)
    {
        return JsonUtil.Serialize(o);
    }
}
