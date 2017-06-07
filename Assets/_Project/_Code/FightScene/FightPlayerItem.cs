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
	public class FightPlayerItem : MonoBehaviour {

        private Image _Leader;
        private Image _HeadIcon;
        private Image _Lock;
        private Image _SkillIcon;
        private Image _ReadyBg;

        private Text _TitleText;
        private Text _PlayerName;
        private Text _CeHuaText;
        private Text _ChengXuText;
        private Text _MeiShuText;
        private Text _SkillName;
        private Text _BtnChangeText;
        private Text _ReadyText;

        private Button _Btn_Delete;
        private Button _Btn_ChangeOrInvite;
        
        private void Awake()
        {
            _Leader = UnityHelper.GetChildNodeComponentScript<Image>(gameObject, "Leader");
            _HeadIcon = UnityHelper.GetChildNodeComponentScript<Image>(gameObject, "HeadIcon");
            _Lock = UnityHelper.GetChildNodeComponentScript<Image>(gameObject, "Lock");
            _SkillIcon = UnityHelper.GetChildNodeComponentScript<Image>(gameObject, "SkillIcon");
            _ReadyBg = UnityHelper.GetChildNodeComponentScript<Image>(gameObject, "ReadyBg");

            _TitleText = UnityHelper.GetChildNodeComponentScript<Text>(gameObject, "TitleText");
            _PlayerName = UnityHelper.GetChildNodeComponentScript<Text>(gameObject, "PlayerName");
            _CeHuaText = UnityHelper.GetChildNodeComponentScript<Text>(gameObject, "CeHuaText");
            _ChengXuText = UnityHelper.GetChildNodeComponentScript<Text>(gameObject, "ChengXuText");
            _MeiShuText = UnityHelper.GetChildNodeComponentScript<Text>(gameObject, "MeiShuText");
            _SkillName = UnityHelper.GetChildNodeComponentScript<Text>(gameObject, "Leader");
            _BtnChangeText = UnityHelper.GetChildNodeComponentScript<Text>(gameObject, "ChangeText");
            _ReadyText = UnityHelper.GetChildNodeComponentScript<Text>(gameObject, "ReadyText");

            _Btn_Delete = UnityHelper.GetChildNodeComponentScript<Button>(gameObject, "Btn_Delete");
            _Btn_ChangeOrInvite = UnityHelper.GetChildNodeComponentScript<Button>(gameObject, "Btn_Change");
        }
    }
}

