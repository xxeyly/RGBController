using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class BaseSlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler,
    IPointerExitHandler
{
    private BaseItem baseItem;

    public BaseItem BaseItem
    {
        get { return baseItem; }
        set
        {
            baseItem = value;
            UpdateView();
        }
    }

    protected Vector3 deviation;
    private Image slotIcon; //物品图标
    private Text slotContent; //物品内容
    private Text slotCount; //物品数量
    private Image slotSelect; //选中遮罩
    private bool isSelect; //是否被选中
    private int currentItemCount;

    public int CurrentItemCount
    {
        get { return currentItemCount; }
        set
        {
            currentItemCount = value;
            UpdateCount();
        }
    }

    // 加载脚本实例时调用 Awake
    protected virtual void Awake()
    {
        slotIcon = transform.Find("SlotIcon").GetComponent<Image>();
        slotContent = transform.Find("SlotContent").GetComponent<Text>();
        slotCount = transform.Find("SlotCount").GetComponent<Text>();
        slotSelect = transform.Find("SlotSelect").GetComponent<Image>();
        deviation = new Vector3(40, -50, 0);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //左键按下
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("左键按下");
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnMouseRightDown();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isSelect = true;
        slotSelect.gameObject.SetActive(true);
        if (baseItem != null)
        {
            OnPointerEnter();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isSelect = false;
        slotSelect.gameObject.SetActive(false);
        OnPointerExit();
    }

    /// <summary>
    /// 使用物品
    /// </summary>
    protected abstract void OnArticlesUsed();

    /// <summary>
    /// 展示物品
    /// </summary>
    protected abstract void DisplayItems();

    /// <summary>
    /// 鼠标进入
    /// </summary>
    protected abstract void OnPointerEnter();

    /// <summary>
    /// 鼠标移出
    /// </summary>
    protected abstract void OnPointerExit();

    protected abstract void OnMouseRightDown();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isSelect)
        {
            OnArticlesUsed();
        }
    }

    /// <summary>
    /// 更新UI
    /// </summary>
    void UpdateView()
    {
        slotIcon.sprite = Resources.Load<Sprite>(baseItem.itemIconPath);
        slotContent.text = baseItem.itemContent;
        slotCount.text = baseItem.itemCurrentCount.ToString();
        currentItemCount = baseItem.itemCurrentCount;
    }

    /// <summary>
    /// 更新数量
    /// </summary>
    void UpdateCount()
    {
        slotCount.text = currentItemCount + "";
        baseItem.itemCurrentCount += 1;
    }
}