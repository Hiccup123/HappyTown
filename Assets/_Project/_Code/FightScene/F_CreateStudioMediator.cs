/***
* 功 能： 创建工作室
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
using UnityEngine.UI;
using PureMVC.Patterns;

namespace Fight
{
	public class F_CreateStudioMediator : Mediator {

        public new const string NAME = "F_CreateStudioMediator";

        private Dropdown _Type;
        private Dropdown _Context;
        private Dropdown _Mode;

        private Button _Btn_Left;
        private Button _Btn_Right;
        private Button _Btn_Random;
        private Button _Btn_Create;
        private Button _Btn_Back;

        public F_CreateStudioMediator(GameObject root) : base(NAME)
        {
            _Type = UnityHelper.GetChildNodeComponentScript<Dropdown>(root, "Drop_Type");
            _Context = UnityHelper.GetChildNodeComponentScript<Dropdown>(root, "Drop_Context");
            _Mode = UnityHelper.GetChildNodeComponentScript<Dropdown>(root, "Drop_Mode");

            _Btn_Left = UnityHelper.GetChildNodeComponentScript<Button>(root, "Btn_Left");
            _Btn_Right = UnityHelper.GetChildNodeComponentScript<Button>(root, "Btn_Right");
            _Btn_Random = UnityHelper.GetChildNodeComponentScript<Button>(root, "Btn_Type");
            _Btn_Create = UnityHelper.GetChildNodeComponentScript<Button>(root, "Btn_Create");
            _Btn_Back = UnityHelper.GetChildNodeComponentScript<Button>(root, "Btn_Back");
        }


	}
}

