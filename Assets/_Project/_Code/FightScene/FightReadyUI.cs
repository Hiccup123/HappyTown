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

namespace Fight
{
	public class FightReadyUI : MonoBehaviour {

        private Text _TitleText;
        private FightPlayerItem _PlayerItem;
        private Button _Btn_Start;
        private Transform _CoinObj;
        private Button _Btn_HuanYiPi;
        private Text _CoinText;

        private List<FightPlayerItem> _PlayerItemList;

        private void Awake()
        {
            _TitleText = UnityHelper.GetChildNodeComponentScript<Text>(gameObject, "_TitleText");
            _PlayerItem = UnityHelper.GetChildNodeComponentScript<FightPlayerItem>(gameObject, "PlayerItem");

            _PlayerItemList = new List<FightPlayerItem>();
            _PlayerItemList.Add(_PlayerItem);

            for (int i = 0;i < 4;i ++)
            {
                GameObject playerItem = Instantiate(_PlayerItem.gameObject) as GameObject;
                UnityHelper.AddChildToParent(playerItem.transform, _PlayerItem.transform.parent.transform, _PlayerItem.transform.localPosition + new Vector3((i + 1) * 350, 0, 0), Vector3.one, Vector3.zero);
                FightPlayerItem fightPlayerItem = playerItem.GetComponent<FightPlayerItem>();
                _PlayerItemList.Add(fightPlayerItem);
            }

            _Btn_Start = UnityHelper.GetChildNodeComponentScript<Button>(gameObject, "_Btn_Start");
            _CoinObj = UnityHelper.FindTheChild(gameObject, "CoinBg");
            _Btn_HuanYiPi = UnityHelper.GetChildNodeComponentScript<Button>(gameObject, "Btn_HuanYiPi");
            _CoinText = UnityHelper.GetChildNodeComponentScript<Text>(gameObject, "CoinText");
        }
    }
}

