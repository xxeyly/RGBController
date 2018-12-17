using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Role : BaseWindow
{
    private Button close;

    protected override void InitView()
    {
        BindUI(ref close, "Close");
    }

    protected override void InitListener()
    {
        close.onClick.AddListener(OnClose);
    }

    /// <summary>
    /// 关闭
    /// </summary>
    void OnClose()
    {
        DisPlay(false);
    }
}