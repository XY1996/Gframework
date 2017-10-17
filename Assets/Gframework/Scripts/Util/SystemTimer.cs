using System;
using UnityEngine;
using UnityEngine.Events;

public class SystemTimer : MonoBehaviour, IDisposable
{

    protected bool Enabled = false;

    public double IntervalMilliseconds { get; set; }

    public double EscapeMilliseconds { get; private set; }

    public DateTime StartTime { get; private set; }

    public UnityAction IntervalEvent { get; set; }

    public void StartTimer()
    {
        StartTime = DateTime.Now;
        EscapeMilliseconds = 0;
        Enabled = true;
    }

    public void StopTimer()
    {
        Enabled = false;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Enabled)
        {
            EscapeMilliseconds = (DateTime.Now- StartTime).TotalMilliseconds;
            if (EscapeMilliseconds >= IntervalMilliseconds)
            {
                IntervalEvent?.Invoke();
                StopTimer();
            }
        }
    }


    public void Dispose()
    {
        StopTimer();
        Destroy(this);
    }

    public static SystemTimer Create(string name)
    {
        GameObject go = new GameObject(name + "Timer");
        return go.AddComponent<SystemTimer>();
    }
}
