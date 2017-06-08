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
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFW
{
	public class MsgCenter : MonoBehaviour {

        public static MsgCenter Instance = null;

        private void Awake()
        {
            Instance = this;

            gameObject.AddComponent<UIManager>();
            gameObject.AddComponent<NPCManager>();
            gameObject.AddComponent<GameManager>();
        }

        public void SendToMsg<T>(MsgBase<T> tempMsg)
        {
            AnalysisMsg(tempMsg);
        }

        private void AnalysisMsg<T>(MsgBase<T> tempMsg)
        {
            ManagerID tempId = tempMsg.GetManager();

            switch(tempId)
            {
                case ManagerID.AssetManager:
                    break;
                case ManagerID.UIManager:
                    break;
                case ManagerID.AudioManager:
                    break;
                case ManagerID.CharactorManager:
                    break;
                case ManagerID.GameManager:
                    break;
                case ManagerID.NetManager:
                    break;
                case ManagerID.NPCManager:
                    break;
                default:
                    break;
            }
        }
    }
}

