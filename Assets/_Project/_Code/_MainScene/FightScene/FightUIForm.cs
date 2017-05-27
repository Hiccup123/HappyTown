/***
* 功 能： 战斗窗体
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
using UIForm;

namespace Fight
{
	public class FightUIForm : BaseUIForms
    {
        private void Awake()
        {
            CurrentUIType.UIForms_Type = UIFormType.Normal;

            
        }
    }
}

