using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem
{
    public enum ItemType
    {
        /// <summary>
        /// 消耗品
        /// </summary>
        EConsumables,

        /// <summary>
        /// 材料
        /// </summary>
        EMaterial,
        /// <summary>
        /// 装备
        /// </summary>
        EEquipment,
    }
    public enum ItemGrade
    {
        White,
        Green,
        Yellow
    }

    /// <summary>
    /// 物品ID
    /// </summary>
    public int itemId;

    /// <summary>
    /// 物品名字
    /// </summary>
    public string itemName;

    /// <summary>
    /// 物品介绍
    /// </summary>
    public string itemContent;

    /// <summary>
    /// 物体图片位置
    /// </summary>
    public string itemIconPath;

    /// <summary>
    /// 物品类型
    /// </summary>
    public ItemType itemType;

    /// <summary>
    /// 当前物品个数
    /// </summary>
    public int itemCurrentCount;
    /// <summary>
    /// 物体上限个数
    /// </summary>
    public int itemMaxCount;

    /// <summary>
    /// 物品出售价格
    /// </summary>
    public int itemSellGold;
}