using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : SingletonMono<GameRoot>
{
    protected override void Awake()
    {
        if(Instance != null)
        {
            // 场上已经有GameRoot -> 在开发中 可能会在每个场景都挂上GameRoot 方便测试 所以跨场景时可能会存在多个GameRoot
            Destroy(gameObject);
            return;
        }
        base.Awake();
        DontDestroyOnLoad(gameObject); // GameRoot伴随整个游戏
        // 初始化所有管理器
        InitMangers();
    }

    private void InitMangers()
    {
        ManagerBase[] managers = GetComponents<ManagerBase>(); // ManagerBase 是 ManagerBase<T> 的父类 方便我们获取时不用管泛型是什么类型 (也可以改成用接口)
        for(int i = 0; i < managers.Length; i++)
        {
            managers[i].Init();
        }
    }
}
