using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 继承Monno单例模式的基类
/// </summary>
public class SingletonMono<T> : MonoBehaviour where T : SingletonMono<T>
{
    public static T Instance;

    protected void Awake()
    {
        Instance = this as T;
    }
}