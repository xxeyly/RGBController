using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWindow : MonoBehaviour
{
    private GameObject window;

    // 加载脚本实例时调用 Awake
    protected virtual void Awake()
    {
        window = transform.Find("Window").gameObject;
        InitView();
        InitListener();
    }

    protected abstract void InitView();
    protected abstract void InitListener();

    public virtual void DisPlay(bool display)
    {
        window.gameObject.SetActive(display);
    }
}