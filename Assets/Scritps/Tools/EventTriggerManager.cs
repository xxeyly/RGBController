using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class EventTriggerManager : MonoBehaviour
{
    #region 单例

    private static EventTriggerManager _instance;

    public static EventTriggerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<EventTriggerManager>();
            }

            return _instance;
        }
    }

    #endregion

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// 为obj添加Eventrigger监听事件
    /// </summary>
    /// <param name="obj">添加监听的对象</param>
    /// <param name="eventID">添加的监听类型</param>
    /// <param name="action">触发的函数</param>
    public void AddTriggersListener(GameObject obj, EventTriggerType eventType, UnityAction<BaseEventData> action)
    {
        //首先判断对象是否已经有EventTrigger组件，若没有那么需要添加
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = obj.AddComponent<EventTrigger>();
            trigger.triggers = new List<EventTrigger.Entry>(); //  
        }

        //定义所要绑定的事件类型 
        EventTrigger.Entry entry = new EventTrigger.Entry
        {
            //设置事件类型  
            eventID = eventType
        };
        //设置回调函数  
        
        entry.callback.AddListener(action);
        //添加事件触发记录到GameObject的事件触发组件  
        trigger.triggers.Add(entry);
    }
}