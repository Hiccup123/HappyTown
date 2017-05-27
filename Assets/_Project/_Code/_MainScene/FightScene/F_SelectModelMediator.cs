/***
* 功 能： 战前准备选择模式
* 描 述： 
*
* 日 期：5/27/2017
* ───────────────────────────────────
* 版 本：v1.0         作 者：LL
*
* Unity版本：5.5.0f3
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using UnityEngine.UI;
using UIForm;
using PureMVC.Interfaces;

namespace Fight
{
	public class F_SelectModelMediator : Mediator {

        public new const string NAME = "F_SelectModelMediator";

        private Button _Btn_Add;
        private Button _Btn_Create;
        private Button _Btn_Back;
        private Text _DescText;

        public F_SelectModelMediator(GameObject root) : base(NAME)
        {
            _Btn_Add = UnityHelper.GetChildNodeComponentScript<Button>(root, "Btn_Add");
            _Btn_Create = UnityHelper.GetChildNodeComponentScript<Button>(root, "Btn_Create");
            _Btn_Back = UnityHelper.GetChildNodeComponentScript<Button>(root, "Btn_Back");
            _DescText = UnityHelper.GetChildNodeComponentScript<Text>(root, "DescText");

            _Btn_Add.onClick.AddListener(OnClickAdd);
            _Btn_Back.onClick.AddListener(OnClickBack);
            _Btn_Create.onClick.AddListener(OnClickCreat);
        }

        void OnClickAdd()
        {
            SendNotification(EventEnums.JOIN_ROOM);
        }

        void OnClickCreat()
        {
            SendNotification(EventEnums.CREATE_ROOM);
        }

        void OnClickBack()
        {
            SendNotification(EventEnums.BACKTOMAIN);
        }
    }
}

