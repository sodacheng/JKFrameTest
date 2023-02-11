using System;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : Singleton<Test1>
{
    public string text = "5555";
}
public class Test : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(Test1.Instance.text);
        Debug.Log(GameRoot.Instance.str);
    }
}


