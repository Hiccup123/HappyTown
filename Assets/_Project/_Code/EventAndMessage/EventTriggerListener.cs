/*
 *  Title : "UIForm"UI框架
 *          主题 : 事件触发监听
 *  Description : 
 *          功能 : 实现对于任何对象的监听处理
 *          
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIFW
{
    public class EventTriggerListener : EventTrigger
    {
        public delegate void UIEventDelegate(GameObject go);
        public UIEventDelegate onClick;
        public UIEventDelegate onDown;
        public UIEventDelegate onEnter;
        public UIEventDelegate onExit;
        public UIEventDelegate onUp;
        public UIEventDelegate onSelect;
        public UIEventDelegate onUpdateSelect;

        /// <summary>
        /// 得到监听器组件
        /// </summary>
        /// <param name="go">监听的游戏对象</param>
        /// <returns>返回监听器</returns>
        public static EventTriggerListener GetListener(GameObject go)
        {
            EventTriggerListener listener = go.GetComponent<EventTriggerListener>();
            if(listener == null)
            {
                listener = go.AddComponent<EventTriggerListener>();
            }

            return listener;
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if(onClick != null)
            {
                onClick(gameObject);
            }
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if(onDown != null)
            {
                onDown(gameObject);
            }
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            if(onEnter != null)
            {
                onEnter(gameObject);
            }
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            if(onExit != null)
            {
                onExit(gameObject);
            }
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            if(onUp != null)
            {
                onUp(gameObject);
            }
        }

        public override void OnSelect(BaseEventData eventData)
        {
            if(onSelect != null)
            {
                onSelect(gameObject);
            }
        }

        public override void OnUpdateSelected(BaseEventData eventData)
        {
            if(onUpdateSelect != null)
            {
                onUpdateSelect(gameObject);
            }
        }
    }
}
