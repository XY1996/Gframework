using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gframework;
using Gframework.Core.Interface;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 这个脚本会根据传入的时间序列，做一系列事情
/// </summary>
public class TimeActionDo : LogicBaseScripts,INodeSpeedControllable {

    /// <summary>
    /// 要发出事件的时间队列,在Update中，如果检测到当前计时器大于等于Time，就会触发当前事件
    /// 单位为秒
    /// </summary>
    public List<TimeAction> FireActions { get; set; }
    /// <summary>
    /// 现在计时器的时间，单位秒
    /// </summary>
    public float CurrentTime { get; private set; }


    /// <summary>
    /// 开始的事件，传出总共要干的事件
    /// </summary>
    public UnityAction<int> StartAction;
    /// <summary>
    /// 结束的事件，传出总共要干的事件，干完的事件
    /// </summary>
    public UnityAction<int, int> EndAction;


    private SortedList<float, TimeAction> sortedList;

    private int totalEventCount=0;
    private bool isRuning = false;
    private bool isPaused = false;
    private float Speed = 1f;


	
	// Update is called once per frame
	void Update () {
	    if (isRuning)
	    {
	        if (!isPaused)
	        {
	            if (!sortedList.Any())
	            {
	                Exit();
	                return;
	            }
	            CurrentTime += Time.deltaTime/Speed;
	            while (sortedList.Any()&&sortedList.First().Key<= CurrentTime)
	            {
	                sortedList.First().Value?.Action();
	                sortedList.RemoveAt(0);
                }
            }
	       
	    }
	}

    /// <summary>
    /// Excute 
    /// </summary>
    /// <exception cref="System.Exception">this.name+" is runing"</exception>>
    protected override void Excute()
    {
        if (isRuning)
        {
            throw new Exception(this.name + " is runing");
        }
        //初始化
        CurrentTime = 0;
        totalEventCount = FireActions.Count;
        //初始化sort list
        sortedList=new SortedList<float, TimeAction>();
        foreach (var gameTest in FireActions)
        {
            sortedList.Add(gameTest.Time,gameTest);
        }
        //开始运行
        isRuning = true;
        StartAction?.Invoke(totalEventCount);
    }

    /// <summary>
    /// Exit Command. Unity 单线程，所以不用考虑sortedList.Count和Update冲突
    /// </summary>
    /// <exception cref="System.Exception">this.name+" is not runing"</exception>>
    protected override void Exit()
    {
        if (!isRuning)
        {
            return;
        }
        isRuning = false;
        EndAction?.Invoke(totalEventCount, totalEventCount-sortedList.Count);
    }

    /// <summary>
    /// Pause
    /// </summary>
    public void Pause()
    {
        isPaused = true;
    }

    /// <summary>
    /// Continue
    /// </summary>
    public void Continue()
    {
        isPaused = false;
    }

    /// <summary>
    /// Change Command Speed
    /// </summary>
    /// <param name="speed"></param>
    public void ChangeSpeed(float speed)
    {
        Speed = speed;
    }
}
