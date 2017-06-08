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
using UIFW;

namespace Fight
{
	public class FMainUI : UIBase {

        private void Awake()
        {
            
        }

        private void Start()
        {
            //Debug.Log("Start");

            GetUIBehaviour("CreateStudio").AddButtonListener(BtnCreateStudio);
            GetUIBehaviour("JoinStudio").AddButtonListener(BtnJoinStudio);
        }

        void BtnCreateStudio()
        {
            Debug.Log("CreateStudio");
            //MsgBase msgBase = new MsgBase((ushort)UIEventFight.CreateSutdio);
            SendMsg((ushort)UIEventFight.CreateSutdio);
        }

        void BtnJoinStudio()
        {
            Debug.Log("JoinStudio");
            SendMsg((ushort)UIEventFight.JoinStudio);
        }
    }
}

