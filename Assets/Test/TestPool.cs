using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPool : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("我产生了");
        Invoke("Dead", 3);
    }

    void Dead()
    {
        PoolManager.Instance.PushGameObject(gameObject);
    }
}
