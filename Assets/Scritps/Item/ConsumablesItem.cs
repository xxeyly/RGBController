using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumablesItem : BaseItem
{

    /// <summary>
    /// 腐坏时间
    /// </summary>
    public float itemRottenTime;
    /// <summary>
    /// 物体使用最低等级
    /// </summary>
    public int itemUseMinLevel;
    /// <summary>
    /// 物品品级
    /// </summary>
    public ItemGrade itemGrade;

}