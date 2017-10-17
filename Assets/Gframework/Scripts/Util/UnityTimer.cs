using System;
using UnityEngine;
using UnityEngine.Events;

public class UnityTimer : MonoBehaviour,IDisposable
{
    private bool isOnDestroy;

    protected bool Enabled=false;

    public double IntervalMilliseconds { get; set; }

    public double EscapeMilliseconds { get; private set; }

    public float StartTime { get; private set; }

    public UnityAction IntervalEvent { get; set; }

    protected UnityTimer()
    {
        
    }

    public void StartTimer()
    {
        StartTime=Time.time;
        EscapeMilliseconds = 0;
        Enabled = true;
    }

    public void StopTimer()
    {
        Enabled = false;
    }

    public void Reset()
    {
        StopTimer();
        IntervalMilliseconds = 0;
        EscapeMilliseconds = 0;
        StartTime = 0;
        IntervalEvent = null;
    }

	// Update is called once per frame
	protected virtual void Update () {
	    if (Enabled)
	    {
           
	        EscapeMilliseconds = (Time.time -StartTime)* 1000;
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
        //这个以后可以改成Pool
        if(!isOnDestroy)
            Destroy(this.gameObject);
    }

    void Start()
    {
        isOnDestroy = false;
    }
    public void OnDestroy()
    {
        isOnDestroy = true;
    }

    public static UnityTimer Create(string name)
    {
        GameObject go=new GameObject(name+"Timer");
        return go.AddComponent<UnityTimer>();
    }


}
