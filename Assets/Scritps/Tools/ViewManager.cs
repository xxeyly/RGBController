using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class ViewManager : MonoBehaviour
{
    #region 单例

    private static ViewManager _instance;

    public static ViewManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ViewManager>();
            }

            return _instance;
        }
    }

    #endregion

    [Header("视图种类")] [SerializeField] private List<ViewType> allViewTypes;
    [Header("视图种类键值对")] [SerializeField] private Dictionary<ViewType.EViewType, GameObject> viewDlc;

    void Start()
    {
        viewDlc = new Dictionary<ViewType.EViewType, GameObject>();
        foreach (ViewType type in allViewTypes)
        {
            if (!viewDlc.ContainsKey(type.viewType))
            {
                viewDlc.Add(type.viewType, type.viewObj);
            }
        }
    }

    /// <summary>
    /// 显示当前视图
    /// </summary>
    public void ShowCurrentView(ViewType.EViewType type)
    {
        GameObject tempView;
        viewDlc.TryGetValue(type, out tempView);
        tempView.GetComponent<DisPlayView>().ShowOrHideView(true);
    }

    /// <summary>
    /// 显示一些视图
    /// </summary>
    /// <param name="types"></param>
    public void ShowSomeView(List<ViewType.EViewType> types)
    {
        foreach (ViewType.EViewType type in types)
        {
            ShowCurrentView(type);
        }
    }

    /// <summary>
    /// 隐藏当前视图
    /// </summary>
    /// <param name="type"></param>
    public void HideCurrentView(ViewType.EViewType type)
    {
        foreach (KeyValuePair<ViewType.EViewType, GameObject> pair in viewDlc)
        {
            if (pair.Key == type)
            {
                pair.Value.GetComponent<DisPlayView>().ShowOrHideView(false);
                break;
            }
        }
    }

    /// <summary>
    /// 隐藏当前视图,并在一定时间内显示其他视图
    /// </summary>
    /// <param name="hideType"></param>
    /// <param name="showType"></param>
    /// <param name="time"></param>
    public void HideCurrentViewLaterShowOtherView(ViewType.EViewType hideType, ViewType.EViewType showType, float time)
    {
        HideCurrentView(hideType);
        StartCoroutine(CurrencyIEnumerator(showType, ShowCurrentView, time));
    }

    /// <summary>
    /// 隐藏一些视图
    /// </summary>
    /// <param name="type"></param>
    public void HideSomeView(List<ViewType.EViewType> types)
    {
        foreach (ViewType.EViewType type in types)
        {
            HideCurrentView(type);
        }
    }

    /// <summary>
    /// 等待一段时间后,显示当前视图
    /// </summary>
    public void ShowCurrentViewLater(ViewType.EViewType type, float time)
    {
        StartCoroutine(CurrencyIEnumerator(type, ShowCurrentView, time));
    }

    /// <summary>
    /// 显示当前视图,但稍后隐藏
    /// </summary>
    public void ShowCurrentViewLaterHide(ViewType.EViewType type, float time)
    {
        ShowCurrentView(type);
        StartCoroutine(CurrencyIEnumerator(type, HideCurrentView, time));
    }

    /// <summary>
    /// 显示当前视图,但稍后隐藏,并执行其他操作
    /// </summary>
    /// <param name="hideType">需要隐藏的视图类型</param>
    /// <param name="laterType">稍后要执行的类型</param>
    /// <param name="time">所需时间</param>
    /// <param name="action">稍后的事件</param>
    public void ShowCurrentViewLaterHideExecution(ViewType.EViewType hideType, ViewType.EViewType laterType,
        UnityAction<ViewType.EViewType> action, float time)
    {
        ShowCurrentView(hideType);
        StartCoroutine(CurrencyIEnumerator(hideType, laterType, HideCurrentView, action, time));
    }

    /// <summary>
    /// 显示当前视图,但稍后隐藏,并执行其他操作
    /// </summary>
    /// <param name="hideType">需要隐藏的视图类型</param>
    /// <param name="laterType">稍后要执行的类型</param>
    /// <param name="time">所需时间</param>
    /// <param name="action">稍后的事件</param>
    public void ShowCurrentViewLaterHideExecution(ViewType.EViewType hideType, List<ViewType.EViewType> laterType,
        UnityAction<List<ViewType.EViewType>> action, float time)
    {
        ShowCurrentView(hideType);
        StartCoroutine(CurrencyIEnumerator(hideType, laterType, HideCurrentView, action, time));
    }


    /// <summary>
    /// 通用协程
    /// </summary>
    /// <param name="time"></param>
    /// <param name="action"></param>
    /// <param name="eType"></param>
    /// <returns></returns>
    IEnumerator CurrencyIEnumerator(ViewType.EViewType eType, UnityAction<ViewType.EViewType> action, float time)
    {
        yield return new WaitForSeconds(time);
        action(eType);
    }

    /// <summary>
    /// 通用协程复数形式
    /// </summary>
    /// <param name="time">执行的时间</param>
    /// <param name="listAction">执行的逻辑</param>
    /// <param name="listType">需要的参数</param>
    /// <returns></returns>
    IEnumerator CurrencyIEnumerator(List<ViewType.EViewType> listType, UnityAction<List<ViewType.EViewType>> action,
        float time)
    {
        yield return new WaitForSeconds(time);
        action(listType);
    }

    /// <summary>
    /// 复杂-类型1
    /// </summary>
    /// <param name="currentType">当前执行的类型</param>
    /// <param name="LaterType">稍后</param>
    /// <param name="currentAction">当前要执行的操作</param>
    /// <param name="LaterAction">稍后要执行的操作</param>
    /// <param name="time">等待时间</param>
    /// <returns></returns>
    IEnumerator CurrencyIEnumerator(ViewType.EViewType currentType, ViewType.EViewType LaterType,
        UnityAction<ViewType.EViewType> currentAction, UnityAction<ViewType.EViewType> LaterAction, float time)
    {
        yield return new WaitForSeconds(time);
        currentAction(currentType);
        LaterAction(LaterType);
    }

    /// <summary>
    /// 复杂-类型2
    /// </summary>
    /// <param name="currentType">当前执行的类型</param>
    /// <param name="LaterType">稍后</param>
    /// <param name="currentAction">当前要执行的操作</param>
    /// <param name="LaterAction">稍后要执行的操作</param>
    /// <param name="time">等待时间</param>
    /// <returns></returns>
    IEnumerator CurrencyIEnumerator(List<ViewType.EViewType> listCurrentType, ViewType.EViewType laterType,
        UnityAction<List<ViewType.EViewType>> currentAction, UnityAction<ViewType.EViewType> LaterAction, float time)
    {
        yield return new WaitForSeconds(time);
        currentAction(listCurrentType);
        LaterAction(laterType);
    }

    /// <summary>
    /// 复杂-类型3
    /// </summary>
    /// <param name="currentType">当前执行的类型</param>
    /// <param name="LaterType">稍后</param>
    /// <param name="currentAction">当前要执行的操作</param>
    /// <param name="LaterAction">稍后要执行的操作</param>
    /// <param name="time">等待时间</param>
    /// <returns></returns>
    IEnumerator CurrencyIEnumerator(ViewType.EViewType currentType, List<ViewType.EViewType> listLaterType,
        UnityAction<ViewType.EViewType> currentAction, UnityAction<List<ViewType.EViewType>> LaterAction, float time)
    {
        yield return new WaitForSeconds(time);
        currentAction(currentType);
        LaterAction(listLaterType);
    }
}

[Serializable]
public class ViewType
{
    public enum EViewType
    {
     
    }

    public EViewType viewType;
    public GameObject viewObj;
}