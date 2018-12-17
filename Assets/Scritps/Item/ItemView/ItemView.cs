using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : BaseWindow
{
    private GameObject consumables;
    private GameObject equipment;
    private Image consumablesItemIcon;
    private Text consumablesItemName;
    private Text consumablesItemContent;
    private Image equipmentItemIcon;
    private Text equipmentItemName;
    private Text equipmentItemContent;

    protected override void InitView()
    {
        BindUI(ref consumables, "ConsumablesItemView");
        BindUI(ref consumablesItemIcon, "ConsumablesItemView/ItemIcon");
        BindUI(ref consumablesItemName, "ConsumablesItemView/ItemName");
        BindUI(ref consumablesItemContent, "ConsumablesItemView/ItemContent");
        BindUI(ref equipment, "EquipmentItemView");
        BindUI(ref equipmentItemIcon, "EquipmentItemView/ItemIcon");
        BindUI(ref equipmentItemName, "EquipmentItemView/ItemName");
        BindUI(ref equipmentItemContent, "EquipmentItemView/ItemContent");

    }

    protected override void InitListener()
    {
    }

    /// <summary>
    /// 修改视图位置
    /// </summary>
    /// <param name="itemType"></param>
    public void OnChangePosition(BaseItem baseItem, Vector3 position)
    {
        switch (baseItem.itemType)
        {
            case BaseItem.ItemType.EConsumables:
                consumables.gameObject.SetActive(true);
                equipment.gameObject.SetActive(false);
                consumables.transform.position = position;
                break;
            case BaseItem.ItemType.EMaterial:
                /*equipment.gameObject.SetActive(true);
                consumables.gameObject.SetActive(false);
                equipment.transform.position = position;*/
                break;
            case BaseItem.ItemType.EEquipment:
                equipment.gameObject.SetActive(true);
                consumables.gameObject.SetActive(false);
                equipment.transform.position = position;
                break;
        }
    }
}