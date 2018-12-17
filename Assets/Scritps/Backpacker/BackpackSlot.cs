using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackSlot : BaseSlot
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnArticlesUsed()
    {
        Debug.Log("背包中使用物品");
    }

    protected override void DisplayItems()
    {
        Debug.Log("箱子中物品展示");
    }

    protected override void OnPointerEnter()
    {
        ViewController.Instance.ShowView(ViewType.EViewType.EItemView);
        FindObjectOfType<ItemView>().OnChangePosition(BaseItem, transform.position + deviation);
    }

    protected override void OnPointerExit()
    {
        ViewController.Instance.HideView(ViewType.EViewType.EItemView);
    }

    protected override void OnMouseRightDown()
    {
        
    }
}