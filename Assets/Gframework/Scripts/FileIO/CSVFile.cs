using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Gframework;
using UnityEngine;

public class CSVFile : IDisposable, IWriteData
{
    private string m_fileFullPath;
    private FileStream fileStream;
    private StreamWriter streamWriter;

    private Type m_type;

    public CSVFile(string fileFullPath,Type type)
    {
        m_fileFullPath = fileFullPath;
        //Set Extension
        m_fileFullPath=Path.ChangeExtension(m_fileFullPath, "csv");

        m_type = type;

        Init(m_fileFullPath, m_type);
    }

    private void Init(string path,Type type)
    {
        if (!File.Exists(path))
        {
            fileStream= new System.IO.FileStream(path, System.IO.FileMode.Create,
                System.IO.FileAccess.ReadWrite);
            streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(string.Join(",",SerializeUtil.GetAllSerializeFieldsName(type)));      
        }
        else
        {
            fileStream = new FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite);
            streamWriter = new StreamWriter(fileStream);
        }
        
    }

    public void WriteData(BaseData data)
    {
    
        streamWriter.WriteLine(data.ToString("csv"));
    }

    public async Task WriteDataAsync(BaseData data)
    {
        await streamWriter.WriteLineAsync(data.ToString("csv"));
    }


    public void Dispose()
    {
        Debug.LogError(m_fileFullPath+" Disposed");
        streamWriter?.Close();
        fileStream?.Close();
        streamWriter?.Dispose();
        fileStream?.Dispose();
    }
}

public class CSVFile<T> :IDisposable where T: BaseData
{

    private string m_fileFullPath;
    private FileStream fileStream;
    private StreamWriter streamWriter;

    public CSVFile(string fileFullPath)
    {
        m_fileFullPath = fileFullPath;

        Init(m_fileFullPath);
    }

    private void Init(string path)
    {
        if (!File.Exists(path))
        {
            File.Create(path);
        }
        fileStream = new FileStream(path, FileMode.Append);
        streamWriter=new StreamWriter(fileStream);
    }

    public void WriteData(T data)
    {
        streamWriter.WriteLine(data.ToString("csv"));
    }


    public async void WriteDataAsync(T data)
    {
        await streamWriter.WriteLineAsync(data.ToString("csv"));
    }

    public List<T> ReadData()
    {
        //!\todo
        throw new NotImplementedException();
    }


    public void Dispose()
    {
        streamWriter?.Dispose();
        fileStream?.Dispose();
    }
}
