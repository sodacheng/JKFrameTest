using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameObjectPoolData
{
    // 对象池中 父节点
    public GameObject fatherObj;

    // 对象容器
    public Queue<GameObject> poolQueue; // List性能消耗更大一些 所以用Queue

    public GameObjectPoolData(GameObject obj, GameObject poolRootObj) // obj -> 要放进对象池的Obj, poolRootObj -> 整个对象池的父节点
    {
        // 创建父节点 并设置到对象池根节点下方
        fatherObj = new GameObject(obj.name);
        fatherObj.transform.SetParent(poolRootObj.transform);
        poolQueue = new Queue<GameObject>();
        // 把首次创建时 需要放入的对象 放进容器
        PushObj(obj);
    }

    /// <summary>
    /// 放进来
    /// </summary>
    /// <param name="obj"></param>
    public void PushObj(GameObject obj)
    {
        // 数据对象添加进容器
        poolQueue.Enqueue(obj);
        // 设置服务器
        obj.transform.SetParent(fatherObj.transform);
        // 设置隐藏
        obj.SetActive(false);
    }

    /// <summary>
    /// 拿出去
    /// </summary>
    /// <returns></returns>
    public GameObject GetObj()
    {
        GameObject obj = poolQueue.Dequeue();

        // 显示对象
        obj.SetActive(true);
        // 父物体置空
        obj.transform.parent = null;
        // 回归当前游戏场景(GameRoot 在 DontDestroyOnLoad)
        SceneManager.MoveGameObjectToScene(obj, SceneManager.GetActiveScene());
        return obj;
    }
}
