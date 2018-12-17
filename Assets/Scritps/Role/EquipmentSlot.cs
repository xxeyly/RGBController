using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : BaseSlot
{

    protected override void OnArticlesUsed()
    {
        Debug.Log("装备栏使用物品");
    }

    protected override void DisplayItems()
    {
        Debug.Log("装备栏展示物品");

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
