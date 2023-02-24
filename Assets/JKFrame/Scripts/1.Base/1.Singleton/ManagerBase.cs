using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 这里也可以用接口
public abstract class ManagerBase : MonoBehaviour 
{
    public virtual void Init() { }
}

public abstract class ManagerBase<T> : ManagerBase where T : ManagerBase<T>
{
    public static T Instance;

    /// <summary>
    /// 管理器的初始化
    /// </summary>
    public override void Init()
    {
        Instance = this as T;
    }
}
