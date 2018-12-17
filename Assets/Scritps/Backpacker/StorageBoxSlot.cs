using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBoxSlot : BaseSlot
{
    private BaseItem baseItem;

    protected override void OnArticlesUsed()
    {
//        Debug.Log("箱子中使用物品");
    }

    protected override void DisplayItems()
    {
//        Debug.Log("箱子中物品展示");
    }

    protected override void OnPointerEnter()
    {
        
    }

    protected override void OnPointerExit()
    {
        
    }

    protected override void OnMouseRightDown()
    {
        
    }
}