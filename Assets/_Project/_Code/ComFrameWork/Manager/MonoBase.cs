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

namespace UIFW
{
	public abstract class MonoBase : MonoBehaviour {

        public abstract void ProcessEvent<T>(MsgBase<T> tempMsg);
	}
}

