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
using UIFW;

namespace Fight
{
	public class FightUIForm : BaseUIForms
    {
        //private FightMainUI _MainUI;
        //private FightCreateUI _CreateUI;
        //private FightReadyUI _ReadyUI;
        //private FightSelectUI _SelectUI;

        private Transform _Main;
        private Transform _Create;
        private Transform _Ready;
        private Transform _Select;

        private Button _Btn_Back;

        private PanelData _PanelData;

        private void Awake()
        {
            //_MainUI = UnityHelper.GetChildNodeComponentScript<FightMainUI>(gameObject, "MainUI");
            //_CreateUI = UnityHelper.GetChildNodeComponentScript<FightCreateUI>(gameObject, "CreateUI");
            //_ReadyUI = UnityHelper.GetChildNodeComponentScript<FightReadyUI>(gameObject, "ReadyUI");
            //_SelectUI = UnityHelper.GetChildNodeComponentScript<FightSelectUI>(gameObject, "SelectUI");
            //_Btn_Back = UnityHelper.GetChildNodeComponentScript<Button>(gameObject, "Btn_Back");

            _PanelData = new PanelData();

            _Main = UnityHelper.FindTheChild(gameObject, "MainUI");
            _Create = UnityHelper.FindTheChild(gameObject, "CreateUI");
            _Ready = UnityHelper.FindTheChild(gameObject, "ReadyUI");
            _Select = UnityHelper.FindTheChild(gameObject, "SelectUI");


            MsgIds = new ushort[]
            {
                (ushort)UIEventFight.FightBack,
                (ushort)UIEventFight.CreateSutdio,
                (ushort)UIEventFight.JoinStudio,
            };

            RegistSelf(this, MsgIds);

            CurrentUIType.UIForms_Type = UIFormType.Normal;
        }

        private void Start()
        {
            _PanelData.PushPanel(_Main.gameObject);
            UIFW.UIManager.Instance.GetGameObject("Btn_Back").GetComponent<UIBehaviour>().AddButtonListener(BtnBack);
        }

        void BtnBack()
        {
            Debug.Log("BackClick");
            MsgBase msgBase = new MsgBase((ushort)UIEventFight.FightBack);
            SendMsg(msgBase);
        }

        public override void ProcessEvent(MsgBase tempMsg)
        {
            switch(tempMsg.MsgId)
            {
                case (ushort)UIEventFight.FightBack:
                    Debug.Log("Back");
                    _PanelData.PopPanel();
                    break;
                case (ushort)UIEventFight.CreateSutdio:
                    Debug.Log("跳转到创建工作室");
                    _PanelData.PushPanel(_Create.gameObject);
                    break;
                case (ushort)UIEventFight.JoinStudio:
                    Debug.Log("跳转到加入工作室");
                    _PanelData.PushPanel(_Ready.gameObject);
                    break;
            }
        }
    }
}

