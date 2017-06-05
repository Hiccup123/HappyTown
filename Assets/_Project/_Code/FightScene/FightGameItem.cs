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
	public class FightGameItem : MonoBehaviour {

        private Text _Title;
        private Text _Type;
        private Text _Content;
        private Text _Style;

        private void Awake()
        {
            _Title = UnityHelper.GetChildNodeComponentScript<Text>(this.gameObject, "TitleText");
            _Type = UnityHelper.GetChildNodeComponentScript<Text>(this.gameObject, "TypeText");
            _Content = UnityHelper.GetChildNodeComponentScript<Text>(this.gameObject, "ContentText");
            _Style = UnityHelper.GetChildNodeComponentScript<Text>(this.gameObject, "StyleText");
        }
    }
}

