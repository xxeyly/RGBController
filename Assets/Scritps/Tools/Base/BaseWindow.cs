using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

    #region UI快速绑定

    protected virtual void BindUI(ref Button uiObj, string uiPath)
    {
        uiObj = transform.Find("Window/" + uiPath).GetComponent<Button>();
    }

    protected virtual void BindUI(ref GameObject uiObj, string uiPath)
    {
        uiObj = transform.Find("Window/" + uiPath).gameObject;
    }

    protected virtual Image BindUI(Image uiObj, string uiPath)
    {
        return transform.Find("Window/" + uiPath).GetComponent<Image>();
    }

    protected virtual Text BindUI(Text uiObj, string uiPath)
    {
        return transform.Find("Window/" + uiPath).GetComponent<Text>();
    }

    #endregion
}