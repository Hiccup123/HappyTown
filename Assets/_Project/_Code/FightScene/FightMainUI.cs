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
	public class FightMainUI : MonoBehaviour {

        private Button _Btn_Create;
        private Button _Btn_Join;

        private void Awake()
        {
            _Btn_Create = UnityHelper.GetChildNodeComponentScript<Button>(this.gameObject,"CreateStudio");
            _Btn_Join = UnityHelper.GetChildNodeComponentScript<Button>(this.gameObject, "JoinStudio");
        }
    }
}

