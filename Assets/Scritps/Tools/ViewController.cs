using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class ViewController : MonoBehaviour
{
    #region 单例

    private static ViewController _instance;

    public static ViewController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ViewController>();
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

    public void ShowView(ViewType.EViewType type)
    {
        GameObject tempView;
        viewDlc.TryGetValue(type, out tempView);
        tempView.GetComponent<BaseWindow>().DisPlay(true);
    }

    public void ShowView(ViewType.EViewType type, float time)
    {
        StartCoroutine(CurrencyIEnumerator(new List<ViewType.EViewType>() {type},
            new List<UnityAction<List<ViewType.EViewType>>>() {ShowView}, time));
    }

    public void ShowView(ViewType.EViewType type, UnityAction action, float time)
    {
        StartCoroutine(CurrencyIEnumerator(new List<ViewType.EViewType>() {type},
            new List<UnityAction<List<ViewType.EViewType>>>() {ShowView}, new List<UnityAction>() {action}, time));
    }

    public void ShowView(ViewType.EViewType type, List<UnityAction> actionList, float time)
    {
        StartCoroutine(CurrencyIEnumerator(new List<ViewType.EViewType>() {type},
            new List<UnityAction<List<ViewType.EViewType>>>() {ShowView}, actionList, time));
    }

    public void ShowView(List<ViewType.EViewType> typeList)
    {
        foreach (ViewType.EViewType type in typeList)
        {
            ShowView(type);
        }
    }

    public void ShowView(List<ViewType.EViewType> typeList, float time)
    {
        StartCoroutine(
            CurrencyIEnumerator(typeList, new List<UnityAction<List<ViewType.EViewType>>>() {ShowView}, time));
    }

    public void ShowView(List<ViewType.EViewType> typeList, UnityAction action, float time)
    {
        StartCoroutine(
            CurrencyIEnumerator(typeList, new List<UnityAction<List<ViewType.EViewType>>>() {ShowView},
                new List<UnityAction>() {action}, time));
    }

    public void ShowView(List<ViewType.EViewType> typeList, List<UnityAction> actionList, float time)
    {
        StartCoroutine(
            CurrencyIEnumerator(typeList, new List<UnityAction<List<ViewType.EViewType>>>() {ShowView}, actionList,
                time));
    }

    public void HideView(ViewType.EViewType type)
    {
        GameObject tempView;
        viewDlc.TryGetValue(type, out tempView);
        tempView.GetComponent<BaseWindow>().DisPlay(false);
    }

    public void HideView(ViewType.EViewType type, float time)
    {
        StartCoroutine(CurrencyIEnumerator(new List<ViewType.EViewType>() {type},
            new List<UnityAction<List<ViewType.EViewType>>>() {HideView}, time));
    }

    public void HideView(ViewType.EViewType type, UnityAction action, float time)
    {
        StartCoroutine(CurrencyIEnumerator(new List<ViewType.EViewType>() {type},
            new List<UnityAction<List<ViewType.EViewType>>>() {HideView}, new List<UnityAction>() {action}, time));
    }

    public void HideView(ViewType.EViewType type, List<UnityAction> actionList, float time)
    {
        StartCoroutine(CurrencyIEnumerator(new List<ViewType.EViewType>() {type},
            new List<UnityAction<List<ViewType.EViewType>>>() {HideView}, actionList, time));
    }

    public void HideView(List<ViewType.EViewType> typeList)
    {
        foreach (ViewType.EViewType type in typeList)
        {
            ShowView(type);
        }
    }

    public void HideView(List<ViewType.EViewType> typeList, float time)
    {
        StartCoroutine(
            CurrencyIEnumerator(typeList, new List<UnityAction<List<ViewType.EViewType>>>() {HideView}, time));
    }

    public void HideView(List<ViewType.EViewType> typeList, UnityAction action, float time)
    {
        StartCoroutine(
            CurrencyIEnumerator(typeList, new List<UnityAction<List<ViewType.EViewType>>>() {ShowView},
                new List<UnityAction>() {action}, time));
    }

    public void HideView(List<ViewType.EViewType> typeList, List<UnityAction> actionList, float time)
    {
        StartCoroutine(
            CurrencyIEnumerator(typeList, new List<UnityAction<List<ViewType.EViewType>>>() {HideView}, actionList,
                time));
    }


    /// <summary>
    /// 通用协程
    /// </summary>
    /// <param name="typeList"></param>
    /// <param name="actionList"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator CurrencyIEnumerator(List<ViewType.EViewType> typeList,
        List<UnityAction<List<ViewType.EViewType>>> actionList, float time)
    {
        yield return new WaitForSeconds(time);
        foreach (UnityAction<List<ViewType.EViewType>> action in actionList)
        {
            action(typeList);
        }
    }

    /// <summary>
    /// 通用协程
    /// </summary>
    /// <param name="typeList"></param>
    /// <param name="actionList"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator CurrencyIEnumerator(List<ViewType.EViewType> typeList,
        List<UnityAction<List<ViewType.EViewType>>> viewActionList, List<UnityAction> actionList, float time)
    {
        yield return new WaitForSeconds(time);
        foreach (UnityAction<List<ViewType.EViewType>> action in viewActionList)
        {
            action(typeList);
        }

        foreach (UnityAction action in actionList)
        {
            action();
        }
    }
}

[System.Serializable]
public class ViewType
{
    public enum EViewType
    {
        /// <summary>
        /// 主界面
        /// </summary>
        EMain,
    }

    public EViewType viewType;
    public GameObject viewObj;
}