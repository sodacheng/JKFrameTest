using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : ManagerBase<PoolManager>
{
    public override void Init()
    {
        base.Init();
        Debug.Log("PoolManager 初始化成功"); // 先调用 ManagerBase 的方法 -> (没有逻辑 向下走) 调用 ManagerBase<T>的方法 -> 调用这里的Debug
    }
}
