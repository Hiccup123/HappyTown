/*
 *  Title : "UIForm" UI框架
 *          主题 : UI窗体父类
 *  Description : 
 *          功能 : 定义所有UI窗体的父类
 *          
 *          定义四个生命周期
 *          1、Display 显示状态
 *          2、Hiding 隐藏状态
 *          3、ReDisplay 再次显示
 *          4、Freeze 冻结状态
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFW;
using System;

namespace UIForm
{
    public class BaseUIForms : UIBase
    {
        //当前（基类）窗口的类型
        private UIType _CurrentUIType = new UIType();

        /*  属性  */
        /// <summary>
        /// 属性_当前UI窗体类型
        /// </summary>
        public UIType CurrentUIType
        {
            set { _CurrentUIType = value; }

            get { return _CurrentUIType; }
        }

        #region UIForm State

        //页面显示
        public virtual void Display()
        {
            this.gameObject.SetActive(true);

            if(_CurrentUIType.UIForms_Type == UIFormType.PopUp)
            {
                UIMaskMgr.Instance.SetMaskWindow(this.gameObject, _CurrentUIType.UIForms_LucencyType);
            }
        }

        //页面隐藏（不在“栈”集合中）
        public virtual void Hiding()
        {
            this.gameObject.SetActive(false);

            if(_CurrentUIType.UIForms_Type == UIFormType.PopUp)
            {
                UIMaskMgr.Instance.CancelMaskWindow();
            }
        }

        //页面重新显示
        public virtual void ReDisplay()
        {
            this.gameObject.SetActive(true);

            if(_CurrentUIType.UIForms_Type == UIFormType.PopUp)
            {
                UIMaskMgr.Instance.SetMaskWindow(this.gameObject, _CurrentUIType.UIForms_LucencyType);
            }
        }

        //页面冻结（还在“栈”集合中）
        public virtual void Freeze()
        {
            this.gameObject.SetActive(true);
        }

        #endregion

        #region Important Method

        /// <summary>
        /// 注册按钮事件
        /// </summary>
        /// <param name="btnName"></param>
        /// <param name="e"></param>
        protected void RegisterButtonEvent(string btnName, EventTriggerListener.UIEventDelegate e)
        {
            GameObject curBtn = UnityHelper.FindTheChild(this.gameObject, btnName).gameObject;

            if(curBtn != null)
            {
                EventTriggerListener.GetListener(curBtn).onClick = e;
            }
        }

        /// <summary>
        /// 打开UI窗体
        /// </summary>
        /// <param name="uiFormName"></param>
        protected void OpenUIForm(string uiFormName)
        {
            UIManager.Instance.ShowUIForm(uiFormName);
        }

        /// <summary>
        /// 关闭UI窗体
        /// </summary>
        protected void CloseUIForm()
        {
            string curUIFormName = string.Empty;
            int indexPos = -1;

            curUIFormName = GetType().ToString();
            Debug.Log("curUIFormName:" + curUIFormName);
            indexPos = curUIFormName.IndexOf('.');
            if(indexPos != -1)
            {
                curUIFormName = curUIFormName.Substring(indexPos + 1);
            }

            UIManager.Instance.CloseOrReturnUIForms(curUIFormName);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msgType">消息类型</param>
        /// <param name="msgName">消息名称</param>
        /// <param name="msgContent">消息内容</param>
        protected void SendMessage(string msgType,string msgName,object msgContent)
        {
            KeyValuesUpdate kv = new UIForm.KeyValuesUpdate(msgName, msgContent);
            MessageCenter.SendMsg(msgType, kv);
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="msgType">消息分类</param>
        /// <param name="msgDelivery">消息委托</param>
        protected void ReceiveMessage(string msgType,MessageCenter.MessageDelivery msgDelivery)
        {
            MessageCenter.AddMsgListener(msgType, msgDelivery);
        }
        #endregion
    }
}
