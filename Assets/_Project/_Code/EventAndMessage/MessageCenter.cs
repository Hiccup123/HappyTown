using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFW
{
    public class MessageCenter
    {
        //消息传递
        public delegate void MessageDelivery(KeyValuesUpdate kv);

        //消息中心缓存集合
        public static Dictionary<string, MessageDelivery> _MsgDic = new Dictionary<string, MessageDelivery>();

        /// <summary>
        /// 增加消息的监听
        /// </summary>
        /// <param name="msgType">消息分类</param>
        /// <param name="msgDelivery">消息委托</param>
        public static void AddMsgListener(string msgType,MessageDelivery msgDelivery)
        {
            if(!_MsgDic.ContainsKey(msgType))
            {
                _MsgDic.Add(msgType, null);
            }
            _MsgDic[msgType] += msgDelivery;
        }

        /// <summary>
        /// 取消消息的监听
        /// </summary>
        /// <param name="msgType">消息分类</param>
        /// <param name="msgDelivery">消息委托</param>
        public static void RemoveMsgListener(string msgType,MessageDelivery msgDelivery)
        {
            if(_MsgDic.ContainsKey(msgType))
            {
                _MsgDic[msgType] -= msgDelivery;
            }
        }

        /// <summary>
        /// 取消所有指定消息的监听
        /// </summary>
        public static void ClearAllMsgListener()
        {
            if(_MsgDic != null)
            {
                _MsgDic.Clear();
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msgType"></param>
        /// <param name="kv"></param>
        public static void SendMsg(string msgType,KeyValuesUpdate kv)
        {
            MessageDelivery msgDelivery;

            if(_MsgDic.TryGetValue(msgType,out msgDelivery))
            {
                if(msgDelivery != null)
                {
                    msgDelivery(kv);
                }
            }
        }
    }

    public class KeyValuesUpdate
    {
        private string _Key;
        public string Key
        {
            get { return _Key; }
        }

        private object _Value;
        public object Value
        {
            get { return _Value; }
        }

        public KeyValuesUpdate(string key,object value)
        {
            _Key = key;
            _Value = value;
        }
    }
}
