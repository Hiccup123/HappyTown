/***
* 功 能： 万能框架
* 描 述： Manager 功能
*           1.存储对应的注册进来的msg
*           2.msg进来后，找到对应脚本 
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
	public class MsgBase{

        //表示 65535 个消息  占两个字节
        public ushort MsgId { get; private set; }

        public ManagerID GetManager()
        {
            int tempId = MsgId / FrameTools.MsgSpan;

            return (ManagerID)(tempId * FrameTools.MsgSpan);
        }

        public MsgBase(ushort tempId)
        {
            MsgId = tempId;
        }
    }

    public class FightMsgBase : MsgBase
    {
        public Transform TransformObj { get; private set; }

        public FightMsgBase(ushort tempId,Transform tempTrans) : base(tempId)
        {
            TransformObj = tempTrans;
        }
    }
}

