/***
* 功 能： N/A
* 描 述： 用空间换取方便
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
	public class Load : UIBase {

        private void Awake()
        {
            MsgIds = new ushort[]
            {
                (ushort)UIEventFight.CreateSutdio,
            };

            RegistSelf(this, MsgIds);
        }

        void Start () 
		{
            UIManager.Instance.GetGameObject("LightOn").GetComponent<UIBehaviour>().AddButtonListener(ButtonClick);
		}
		
		public void ButtonClick()
        {
            MsgBase msgBase = new MsgBase((ushort)UIEventFight.CreateSutdio);
            SendMsg(msgBase);
        }

        public override void ProcessEvent(MsgBase tempMsg)
        {
            switch(tempMsg.MsgId)
            {
                case (ushort)UIEventFight.CreateSutdio:
                    break;
            }
        }
    }
}

