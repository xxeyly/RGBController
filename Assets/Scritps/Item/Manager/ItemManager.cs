using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using LitJson;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance;

    public static ItemManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<ItemManager>();
            }
            return instance;
        }
    }

    /// <summary>
    /// 背包中存储的物品
    /// </summary>
    private Dictionary<int, BaseItem> backpackItemDic;

    /// <summary>
    /// 所有物品键值对
    /// </summary>
    private Dictionary<int, BaseItem> allItemDic;

    /// <summary>
    /// 所有物品
    /// </summary>
    private List<BaseItem> allItemList;

    /// <summary>
    /// 物品Json数据
    /// </summary>
    private TextAsset itemJson;

    private void Awake()
    {
        backpackItemDic = new Dictionary<int, BaseItem>();
        allItemDic = new Dictionary<int, BaseItem>();
        itemJson = Resources.Load<TextAsset>("Data/Item/Item");
    }

    void Start()
    {
        AnalysisJson();
    }

    /// <summary>
    /// 解析背包数据,Json格式
    /// </summary>
    void AnalysisJson()
    {
        JsonData jsonData = JsonMapper.ToObject(itemJson.text);
        //通过索引的方式获取json中的信息，既可以使用索引位置，也可以使用索引键名
        for (int i = 0; i < jsonData.Count; i++)
        {
            BaseItem tempBaseItem = new BaseItem
            {
                itemName = jsonData[i]["itemName"].ToString(),
                itemId = int.Parse(jsonData[i]["itemId"].ToString()),
                itemContent = jsonData[i]["itemContent"].ToString(),
                itemIconPath = jsonData[i]["itemIconPath"].ToString(),
                itemType = (BaseItem.ItemType) int.Parse(jsonData[i]["itemType"].ToString()),
                itemMaxCount = int.Parse(jsonData[i]["itemMaxCount"].ToString()),
                itemSellGold = int.Parse(jsonData[i]["itemSellGold"].ToString()),
                itemCurrentCount = int.Parse(jsonData[i]["itemCurrentCount"].ToString())
            };
            BaseItem.ItemType itemType = (BaseItem.ItemType) int.Parse(jsonData[i]["itemType"].ToString());
            switch (itemType)
            {
                case BaseItem.ItemType.EConsumables:

                    #region ConsumablesItem 数据解析

                    ConsumablesItem tempConsumablesItem = new ConsumablesItem
                    {
                        itemId = tempBaseItem.itemId,
                        itemName = tempBaseItem.itemName,
                        itemContent = tempBaseItem.itemContent,
                        itemIconPath = tempBaseItem.itemIconPath,
                        itemType = tempBaseItem.itemType,
                        itemMaxCount = tempBaseItem.itemMaxCount,
                        itemSellGold = tempBaseItem.itemSellGold,
                        itemCurrentCount = tempBaseItem.itemCurrentCount,
                        itemUseMinLevel = int.Parse(jsonData[i]["itemUseMinLevel"].ToString()),
                        itemGrade = (BaseItem.ItemGrade) int.Parse(jsonData[i]["itemGrade"].ToString()),
                        itemRottenTime = int.Parse(jsonData[i]["itemRottenTime"].ToString())
                    };
                    allItemDic.Add(tempConsumablesItem.itemId, tempConsumablesItem);

                    #endregion

                    break;
                case BaseItem.ItemType.EMaterial:
                    break;
                case BaseItem.ItemType.EEquipment:

                    #region Equipment 数据解析

                    EquipmentItem tempEquipmentItem = new EquipmentItem
                    {
                        itemId = tempBaseItem.itemId,
                        itemName = tempBaseItem.itemName,
                        itemContent = tempBaseItem.itemContent,
                        itemIconPath = tempBaseItem.itemIconPath,
                        itemType = tempBaseItem.itemType,
                        itemMaxCount = tempBaseItem.itemMaxCount,
                        itemSellGold = tempBaseItem.itemSellGold,
                        itemCurrentCount = tempBaseItem.itemCurrentCount,
                        itemUseMinLevel = int.Parse(jsonData[i]["itemUseMinLevel"].ToString()),
                        itemGrade = (BaseItem.ItemGrade) int.Parse(jsonData[i]["itemGrade"].ToString())
                    };

                    allItemDic.Add(tempEquipmentItem.itemId, tempEquipmentItem);

                    #endregion

                    break;
            }
        }
    }

    /// <summary>
    /// 获得一个新物品
    /// </summary>
    /// <returns></returns>
    public BaseItem GetNewItem(int index)
    {
        switch (allItemDic[index].itemType)
        {
            case BaseItem.ItemType.EConsumables:
                ConsumablesItem tempConsumablesItem = (ConsumablesItem) allItemDic[index];
                return new ConsumablesItem
                {
                    itemId = tempConsumablesItem.itemId,
                    itemName = tempConsumablesItem.itemName,
                    itemContent = tempConsumablesItem.itemContent,
                    itemIconPath = tempConsumablesItem.itemIconPath,
                    itemType = tempConsumablesItem.itemType,
                    itemMaxCount = tempConsumablesItem.itemMaxCount,
                    itemSellGold = tempConsumablesItem.itemSellGold,
                    itemUseMinLevel = tempConsumablesItem.itemUseMinLevel,
                    itemGrade = tempConsumablesItem.itemGrade,
                    itemCurrentCount = tempConsumablesItem.itemCurrentCount,
                    itemRottenTime = tempConsumablesItem.itemRottenTime
                };
            case BaseItem.ItemType.EMaterial:
                break;
            case BaseItem.ItemType.EEquipment:
                EquipmentItem tempEquipmentItem = (EquipmentItem) allItemDic[index];
                return new ConsumablesItem
                {
                    itemId = tempEquipmentItem.itemId,
                    itemName = tempEquipmentItem.itemName,
                    itemContent = tempEquipmentItem.itemContent,
                    itemIconPath = tempEquipmentItem.itemIconPath,
                    itemType = tempEquipmentItem.itemType,
                    itemMaxCount = tempEquipmentItem.itemMaxCount,
                    itemSellGold = tempEquipmentItem.itemSellGold,
                    itemUseMinLevel = tempEquipmentItem.itemUseMinLevel,
                    itemGrade = tempEquipmentItem.itemGrade,
                    itemCurrentCount = tempEquipmentItem.itemCurrentCount,
                };
        }

        return null;
    }
}