/***
* 功 能： N/A
* 描 述： Controller 层
*
* 日 期：6/6/2017
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
	public class UIBase : MonoBase {

        public ushort[] MsgIds;

        public void RegistSelf(MonoBase mono,params ushort[] msgs)
        {
            UIManager.Instance.RegistMsg(mono, msgs);
        }

        public void UnRegistSelf(MonoBase mono,params ushort[] msgs)
        {
            UIManager.Instance.UnRegistMsg(mono, msgs);
        }

        #region SendMsg
        public void SendMsg(ushort tempMsgId)
        {
            UIManager.Instance.SendMsg(new MsgBase<object>(tempMsgId));
        }

        public void SendMsg<T>(ushort tempMsgId)
        {
            UIManager.Instance.SendMsg(new MsgBase<T>(tempMsgId));
        }

        public void SendMsg<T>(ushort tempMsgId,T body)
        {
            UIManager.Instance.SendMsg(new MsgBase<T>(tempMsgId,body));
        }
        #endregion

        public override void ProcessEvent<T>(MsgBase<T> tempMsg)
        {
            
        }

        protected UIBehaviour GetUIBehaviour(string name)
        {
            return UIManager.Instance.GetUIBehaviour(name);
        }

        private void OnDestroy()
        {
            if (MsgIds != null)
            {
                UnRegistSelf(this, MsgIds);
            }
        }
    }
}

