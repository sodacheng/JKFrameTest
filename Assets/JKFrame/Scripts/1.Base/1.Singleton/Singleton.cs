using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 单例模式的基类
/// </summary>
public class Singleton<T> where T :  Singleton<T>,new()
{
    private static T instnce;

    public static T Instance
    {
        get
        {
            if (instnce == null)
            {
                instnce = new T();
            }

            return instnce;
        }
    }
}