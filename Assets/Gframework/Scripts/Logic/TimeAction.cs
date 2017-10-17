using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 啥时候干啥事情
/// </summary>
public class TimeAction {

    public float Time
    {
        get; private set;
        
    }

    public UnityAction Action
    {
        get; private set; 
        
    }

    public TimeAction(float time, UnityAction action)
    {
        Time = time;
        Action = action;
    }
}
