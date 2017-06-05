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
using UnityEngine.UI;

namespace Fight
{
	public class FightUIForm : BaseUIForms
    {
        private FightMainUI _MainUI;
        private FightCreateUI _CreateUI;
        private FightReadyUI _ReadyUI;
        private FightSelectUI _SelectUI;

        private Button _Btn_Back;

        private void Awake()
        {
            _MainUI = UnityHelper.GetChildNodeComponentScript<FightMainUI>(gameObject, "MainUI");
            _CreateUI = UnityHelper.GetChildNodeComponentScript<FightCreateUI>(gameObject, "CreateUI");
            _ReadyUI = UnityHelper.GetChildNodeComponentScript<FightReadyUI>(gameObject, "ReadyUI");
            _SelectUI = UnityHelper.GetChildNodeComponentScript<FightSelectUI>(gameObject, "SelectUI");
            _Btn_Back = UnityHelper.GetChildNodeComponentScript<Button>(gameObject, "Btn_Back");

            CurrentUIType.UIForms_Type = UIFormType.Normal;
        }
    }
}

