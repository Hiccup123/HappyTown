/***
* 功 能： 战斗模块启动命令
* 描 述： 
*
* 日 期：5/26/2017
* ───────────────────────────────────
* 版 本：v1.0         作 者：LL
*
* Unity版本：5.5.0f3
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace Fight
{
	public class FightStartUpCommand : SimpleCommand {

        public override void Execute(INotification notification)
        {
            FightUIForm uiForm = notification.Body as FightUIForm;
            
        }
    }
}

