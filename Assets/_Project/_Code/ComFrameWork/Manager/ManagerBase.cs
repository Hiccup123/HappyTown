/***
* 功 能： N/A
* 描 述： 
*
* 日 期：6/5/2017
* ───────────────────────────────────
* 版 本：v1.0         作 者：LL
*
* Unity版本：5.5.0f3
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFW
{
    public class EventNode
    {
        //当前数据
        public MonoBase data;

        //指向下一个节点
        public EventNode next;

        public EventNode(MonoBase tempMono)
        {
            this.data = tempMono;
            this.next = null;
        }
    }

	public class ManagerBase : MonoBase {

        //存储注册消息 key  value
        public Dictionary<ushort, EventNode> eventTree = new Dictionary<ushort, EventNode>();

        #region Register Mono Message
        /// <summary>
        /// 注册脚本
        /// </summary>
        /// <param name="mono">要注册的脚本</param>
        /// <param name="msgs">脚本 可以注册多个msg</param>
        public void RegistMsg(MonoBase mono,params ushort[] msgs)
        {
            for(int i = 0;i < msgs.Length;i ++)
            {
                EventNode node = new EventNode(mono);

                RegistMsg(msgs[i], node);
            }
        }

        /// <summary>
        /// 注册脚本节点
        /// </summary>
        /// <param name="id">根据msgId</param>
        /// <param name="node">node链表</param>
        private void RegistMsg(ushort id,EventNode tempNode)
        {
            if(!eventTree.ContainsKey(id))
            {
                eventTree.Add(id, tempNode);
            }
            else
            {
                EventNode node = eventTree[id];
                //找到最后一个车厢
                while(node.next != null)
                {
                    node = node.next;
                }
                //直接挂到最后
                node.next = tempNode;
            }
        }
        #endregion

        #region Remove Mono Message
        /// <summary>
        /// 去掉一个脚本的若干的消息
        /// </summary>
        /// <param name="mono"></param>
        /// <param name="msgs">可变数组参数</param>
        public void UnRegistMsg(MonoBase mono,params ushort[] msgs)
        {
            for(int i = 0;i < msgs.Length;i ++)
            {
                UnRegistMsg(msgs[i], mono);
            }
        }

        /// <summary>
        /// 去掉一个消息链表
        /// 释放：
        /// 1.直接在尾部释放
        /// 2.在中间
        /// 3.在头部释放
        /// </summary>
        /// <param name="id"></param>
        /// <param name="node"></param>
        private void UnRegistMsg(ushort id,MonoBase tempNode)
        {
            if(!eventTree.ContainsKey(id))
            {
                Debug.LogError("EventTree not contain id == " + id);
                return;
            }
            else
            {
                EventNode node = eventTree[id];

                if(node.data == tempNode)   //释放头部
                {
                    EventNode header = node;
                    //已经存在这个消息
                    if(header.next != null) //多个节点
                    {
                        //header.data = node.next.data;
                        //header.next = node.next.next;

                        eventTree[id] = node.next;  //直接指向下一个
                        header.next = null;     //把第一个直接指向null
                    }
                    else  //只有一个节点的情况
                    {
                        eventTree.Remove(id);
                    }
                }
                else  //去掉尾部和中间的几点
                {
                    //下一个不是我要找的node 就一直遍历
                    while(node.next != null && node.next.data != tempNode)
                    {
                        node = node.next;
                    }   //表示已经找到了该节点

                    //没有引用会自动释放
                    if(node.next.next != null)  //去掉中间的
                    {
                        EventNode curNode = node.next;
                        node.next = curNode.next;
                        curNode.next = null;    //把相关联的指针释放
                        //node.next = node.next.next;
                    }
                    else    //去掉尾部的
                    {
                        //EventNode curNode = node.next;
                        //node 表示要找的节点的上一个节点
                        node.next = null;
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 来了消息 通知整个消息链表
        /// </summary>
        /// <param name="tempMsg"></param>
        public override void ProcessEvent<T>(MsgBase<T> tempMsg)
        {
            if(!eventTree.ContainsKey(tempMsg.MsgId))
            {
                Debug.LogError("Msg not contains MsgId == " + tempMsg.MsgId);
                Debug.LogError("Msg Manager == " + tempMsg.GetManager());
            }
            else
            {
                //Debug.Log("tempMsg:" + tempMsg.MsgId);

                //通过key 找到链表 全部通知
                EventNode tempNode = eventTree[tempMsg.MsgId];
                //Debug.Log("tempNode:" + tempNode);
                //Debug.Log("tempNode.data:" + tempNode.data);
                //Debug.Log("tempNode.next:" + tempNode.next);
 
                do
                {
                    //Debug.Log("do:");
                    //策略模式
                    tempNode.data.ProcessEvent(tempMsg);
                    tempNode = tempNode.next;
                }
                while (tempNode != null);
            }
        }
    }
}

