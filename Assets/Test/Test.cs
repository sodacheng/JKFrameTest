using System;
using System.Collections.Generic;
using UnityEngine;
public class Test : MonoBehaviour
{
    public GameObject Cube;
    private void Start()
    {
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            PoolManager.Instance.GetGameObject<TestPool>(Cube);
        }
    }
}


