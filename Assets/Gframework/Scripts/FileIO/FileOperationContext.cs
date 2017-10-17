using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gframework;
using UnityEngine;


/// <summary>
/// 全自动处理文件
/// </summary>
public class FileOperationContext:IWriteData
{

    private Dictionary<Type, IWriteData> writeDataOperation;


    public FileOperationContext(IEnumerable<KeyValuePair<Type, IWriteData>> typeFilePathPairs)
    {
        writeDataOperation=new Dictionary<Type, IWriteData>();
        foreach (var typeFilePathPair in typeFilePathPairs)
        {
            writeDataOperation.Add(typeFilePathPair.Key, typeFilePathPair.Value);
        }   
    }


    public void WriteData(BaseData data)
    {
        Type t = data.GetType();
        if (!writeDataOperation.Keys.Contains(t))
        {
            throw  new KeyNotFoundException("type not found");
        }
        writeDataOperation[t].WriteData(data);
    }

    public async Task WriteDataAsync(BaseData data)
    {
        Type t = data.GetType();
        if (!writeDataOperation.Keys.Contains(t))
        {
            throw new KeyNotFoundException("type not found");
        }
        await writeDataOperation[t].WriteDataAsync(data);
    }

    public void Dispose()
    {
        foreach ( var operation in writeDataOperation.Values)
        {
            operation?.Dispose();
        }
        writeDataOperation = null;
    }

}
