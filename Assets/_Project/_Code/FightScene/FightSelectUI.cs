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
	public class FightSelectUI : MonoBehaviour {

        private FightGameItem _Game_Item;
        private List<FightGameItem> _GameItemList;

        private Text _Coin_Num;
        private Button _Btn_HuanYiPi;

        private void Awake()
        {
            _Game_Item = UnityHelper.GetChildNodeComponentScript<FightGameItem>(this.gameObject, "GameItem");
            _GameItemList = new List<FightGameItem>();
            _GameItemList.Add(_Game_Item);

            for(int i = 0;i < 2;i ++)
            {
                GameObject gameItem = Instantiate(_Game_Item.gameObject) as GameObject;
                UnityHelper.AddChildToParent(gameItem.transform, _Game_Item.transform.parent.transform, _Game_Item.gameObject.transform.localPosition + new Vector3((i + 1) * 610, 0, 0), Vector3.one, Vector3.zero);
                
                FightGameItem fightGameItem = gameItem.GetComponent<FightGameItem>();
                _GameItemList.Add(fightGameItem);
            }
            Debug.Log("_GameItemList.Count:" + _GameItemList.Count);

            _Coin_Num = UnityHelper.GetChildNodeComponentScript<Text>(this.gameObject, "CoinText");
            _Btn_HuanYiPi = UnityHelper.GetChildNodeComponentScript<Button>(this.gameObject, "Btn_HuanYiPi");
        }

    }
}

