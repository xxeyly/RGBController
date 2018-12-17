using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemOperation : BaseWindow
{
    private static ItemOperation _Instance;

    public static ItemOperation Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = GameObject.FindObjectOfType<ItemOperation>();
            }

            return _Instance;
        }
    }

    private GameObject OperationPanel;
    private Button used;
    private Button drop;
    private Button split;
    private BaseItem baseItem;
    protected override void InitView()
    {
        BindUI(ref OperationPanel, "OperationPanel");
        BindUI(ref used, "OperationPanel/Used");
        BindUI(ref drop, "OperationPanel/Drop");
        BindUI(ref split, "OperationPanel/Split");
    }

    protected override void InitListener()
    {
        BindListener(ref used, OnUsed);
        BindListener(ref drop, OnDrop);
        BindListener(ref split, OnSplit);
    }

    void OnUsed()
    {
    }

    void OnDrop()
    {
    }

    void OnSplit()
    {
    }
    /// <summary>
    /// 更改位置
    /// </summary>
    /// <param name="position"></param>
    public void OnChangePosition(Vector3 position)
    {
        this.transform.position = position;
    }

    public void OnChangeItem(BaseItem item)
    {
        this.baseItem = item;
    }
}