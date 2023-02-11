using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
/// <summary>
/// JKFrame框架主要的拓展方法
/// </summary>
public static class JKExtension
{
    #region 通用
    /// <summary>
    /// 获取特性
    /// </summary>
    public static T GetAttribute<T>(this object obj) where T:Attribute // 约束 T 必须是特性
    {
        return obj.GetType().GetCustomAttribute<T>();
    }
    
    /// <summary>
    /// 获取指定类型上的特性 => 需要外部判空
    /// </summary>
    /// <param name="type"/>特性所在的类型</param>
    public static T GetAttribute<T>(this object obj, Type type) where T:Attribute // 约束 T 必须是特性
    {
        return type.GetCustomAttribute<T>();
    }
    #endregion

}
