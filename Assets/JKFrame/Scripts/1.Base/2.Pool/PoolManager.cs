using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : ManagerBase<PoolManager>
{
    // 根节点
    [SerializeField]private GameObject poolRootObj;
    /// <summary>
    /// GameObject对象容器
    /// </summary>
    public Dictionary<string, GameObjectPoolData> gameObjectPoolDic = new Dictionary<string, GameObjectPoolData>();
    public override void Init()
    {
        base.Init();
        
    }

    /// <summary>
    /// 获取GameObject(返回Component)
    /// </summary>
    /// <typeparam name="T">最终需要的组件</typeparam>
    /// <param name="prefab"></param>
    /// <returns></returns>
    public T GetGameObject<T>(GameObject prefab) where T : UnityEngine.Object
    {
        GameObject obj = GetGameObject(prefab);
        if(obj != null)
        {
            return obj.GetComponent<T>();
        }
        return null;
    }

    /// <summary>
    /// 获取GameObject
    /// </summary>
    /// <param name="prefab"></param>
    /// <returns></returns>
    public GameObject GetGameObject(GameObject prefab)
    {
        GameObject obj = null;
        string name = prefab.name; // 物体的名称
        // 检查pollRoot有没有这一层
        if(CheckGameObjectCache(prefab))
        {
            obj = gameObjectPoolDic[name].GetObj();
        }
        // 没有的话实例化一个
        else
        {
            obj = GameObject.Instantiate(prefab);
            obj.name = name; // 保证实例化后的游戏物体 名称都和预制体一致
        }
        return obj;
    }

    /// <summary>
    /// GameObject放进对象池
    /// </summary>
    /// <param name="obj"></param>
    public void PushGameObject(GameObject obj)
    {
        string name = obj.name;
        // 现在有没有这一层
        if (gameObjectPoolDic.ContainsKey(name))
        {
            gameObjectPoolDic[name].PushObj(obj);
        }
        else
        {
            gameObjectPoolDic.Add(name, new GameObjectPoolData(obj, poolRootObj));
        }
    }

    /// <summary>
    /// 检查有没有某一层对象池数据
    /// </summary>
    /// <param name="prefab"></param>
    /// <returns></returns>
    public bool CheckGameObjectCache(GameObject prefab)
    {
        string name = prefab.name;
        return gameObjectPoolDic.ContainsKey(name) && gameObjectPoolDic[name].poolQueue.Count > 0; // 有没有这一层 && 这一层里有没有缓存的Obj
    }

    public void Clear()
    {
        gameObjectPoolDic.Clear();
    }
}
