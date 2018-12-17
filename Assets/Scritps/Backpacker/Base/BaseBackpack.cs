using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseBackpack : BaseWindow
{
    private List<BaseSlot> backpackSlots;
    private Button close; //关闭按钮
    private Button arrange; //整理按钮
    private GameObject slotParent; //格子的父物体

    protected override void Awake()
    {
        base.Awake();
        backpackSlots = new List<BaseSlot>(slotParent.GetComponentsInChildren<BaseSlot>());
    }

    protected override void InitView()
    {
        BindUI(ref close, "Close");
        BindUI(ref arrange, "Arrange");
        BindUI(ref slotParent, "SlotParent");
    }

    protected override void InitListener()
    {
        close.onClick.AddListener(OnClose);
        arrange.onClick.AddListener(OnArrange);
    }

    /// <summary>
    /// 关闭监听
    /// </summary>
    protected virtual void OnClose()
    {
        DisPlay(false);
    }

    /// <summary>
    /// 整理监听
    /// </summary>
    protected virtual void OnArrange()
    {
    }

    /// <summary>
    /// 增加物品
    /// </summary>
    /// <param name="itemIndex"></param>
    public virtual void AddItem(int itemIndex)
    {
        if (FindIdenticalSlot(itemIndex) != null)
        {
            //得到合适条件的格子,并且数量+1
            FindIdenticalSlot(itemIndex).CurrentItemCount += 1;
        }
        else
        {
            //找到空格子,并且赋值格子的BaseItem
            if (FindEmptySlot() != null)
            {
                FindEmptySlot().BaseItem = ItemManager.Instance.GetNewItem(itemIndex);
            }
            else
            {
                Debug.Log("背包空间已满");
            }
        }
    }

    /// <summary>
    /// 查找空格子
    /// </summary>
    /// <returns></returns>
    private BaseSlot FindEmptySlot()
    {
        foreach (BaseSlot baseSlot in backpackSlots)
        {
            if (baseSlot.BaseItem == null)
            {
                return baseSlot;
            }
        }

        return null;
    }

    /// <summary>
    /// 查找相同的格子,并且符合存储要求
    /// </summary>
    /// <returns></returns>
    private BaseSlot FindIdenticalSlot(int itemId)
    {
        foreach (BaseSlot baseSlot in backpackSlots)
        {
            if (baseSlot.BaseItem != null)
            {
                //找到相同的物品
                if (baseSlot.BaseItem.itemId == itemId)
                {
                    //并且物品没有达到上限
                    if (baseSlot.CurrentItemCount < baseSlot.BaseItem.itemMaxCount)
                    {
                        return baseSlot;
                    }
                }
            }
        }

        return null;
    }
}