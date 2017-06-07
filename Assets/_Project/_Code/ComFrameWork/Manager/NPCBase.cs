/***
* 功 能： N/A
* 描 述： 
*
* 日 期：6/6/2017
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
	public class NPCBase : MonoBase {

        public ushort[] MsgIds;

        public void RegistSelf(MonoBase mono, params ushort[] msgs)
        {
            NPCManager.Instance.RegistMsg(mono, msgs);
        }

        public void UnRegistSelf(MonoBase mono, params ushort[] msgs)
        {
            NPCManager.Instance.UnRegistMsg(mono, msgs);
        }

        public void SendMsg<T>(MsgBase<T> tempMsg)
        {
            NPCManager.Instance.SendMsg(tempMsg);
        }

        public override void ProcessEvent<T>(MsgBase<T> tempMsg)
        {

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

