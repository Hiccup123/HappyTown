/***
* 功 能： N/A
* 描 述： 释放：
*           1.直接在尾部释放
*           2.在中间
*
* 日 期：6/5/2017
* ───────────────────────────────────
* 版 本：v1.0         作 者：LL
*
* Unity版本：5.5.0f3
*/
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mono">要注册的脚本</param>
        /// <param name="msgs">脚本 可以注册多个msg</param>
        public void RegistMsg(MonoBase mono,params ushort[] msgs)
        {
            for(int i = 0;i < msgs.Length;i ++)
            {
                EventNode tempNode = new EventNode(mono);

                RegistMsg(msgs[i], tempNode);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">根据msgId</param>
        /// <param name="node">node链表</param>
        public void RegistMsg(ushort id,EventNode node)
        {
            if(!eventTree.ContainsKey(id))
            {
                eventTree.Add(id, node);
            }
            else
            {
                EventNode tempNode = eventTree[id];
                //找到最后一个车厢
                while(tempNode.next != null)
                {
                    tempNode = tempNode.next;
                }
                //直接挂到最后
                tempNode.next = node;
            }
        }

        public void UnRegistMsg(ushort id,MonoBase node)
        {

        }
	}
}

