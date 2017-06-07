/***
* 功 能： N/A
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
using UnityEngine.UI;
using UIFW;

namespace Fight
{
	public class FightCreateUI : MonoBehaviour {

        private Dropdown _TypeDrop;
        private Dropdown _ContentDrop;
        private Dropdown _StyleDrop;

        private Text _NeedMoney;
        private Text _GameName;

        private Button _Btn_Left;
        private Button _Btn_Right;
        private Button _Btn_Create;

        private void Awake()
        {
            _TypeDrop = UnityHelper.GetChildNodeComponentScript<Dropdown>(gameObject, "TypeDrop");
            _ContentDrop = UnityHelper.GetChildNodeComponentScript<Dropdown>(gameObject, "ContentDrop");
            _StyleDrop = UnityHelper.GetChildNodeComponentScript<Dropdown>(gameObject, "StyleDrop");
            _NeedMoney = UnityHelper.GetChildNodeComponentScript<Text>(gameObject, "Money");
            _GameName = UnityHelper.GetChildNodeComponentScript<Text>(gameObject, "GameName");
            _Btn_Right = UnityHelper.GetChildNodeComponentScript<Button>(gameObject, "Btn_Right");
            _Btn_Left = UnityHelper.GetChildNodeComponentScript<Button>(gameObject, "Btn_Left");
            _Btn_Create = UnityHelper.GetChildNodeComponentScript<Button>(gameObject, "Btn_Create");
        }
    }
}

