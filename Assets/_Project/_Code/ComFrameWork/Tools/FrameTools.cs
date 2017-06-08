/***
* 功 能： 万能框架
* 描 述： 
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
    //192.168.0
    public enum ManagerID
    {
        GameManager = 0,
        UIManager = FrameTools.MsgSpan,            //3000
        AudioManager = FrameTools.MsgSpan * 2,     //6000
        NPCManager = FrameTools.MsgSpan * 3,
        CharactorManager = FrameTools.MsgSpan * 4,
        AssetManager = FrameTools.MsgSpan * 5,
        NetManager = FrameTools.MsgSpan * 6,
    }

    public class FrameTools{

        public const int MsgSpan = 3000;

        
	}
}

