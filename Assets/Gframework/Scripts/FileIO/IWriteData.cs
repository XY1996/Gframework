using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gframework;
using UnityEngine;

public interface IWriteData:IDisposable
{
    void WriteData(BaseData data);
    Task WriteDataAsync(BaseData data);
}
