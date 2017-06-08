/***
* 功 能： N/A
* 描 述： 
*
* 日 期：6/6/2017
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
	public class PanelData {

        private Stack<GameObject> _PanelStack;

        public PanelData()
        {
            _PanelStack = new Stack<GameObject>();
        }

        public void PushPanel(GameObject obj)
        {
            if(_PanelStack.Count > 0)
            {
                if(_PanelStack.Peek() == obj)
                {
                    return;
                }
                _PanelStack.Peek().SetActive(false);
            }
            obj.SetActive(true);
            _PanelStack.Push(obj);
        }

        public void PopPanel()
        {
            if(_PanelStack.Count >= 2)
            {
                _PanelStack.Pop().SetActive(false);
                _PanelStack.Peek().SetActive(true);
            }
            else
            {
                //ClearPanelStack();
            }
        }

        public bool ClearPanelStack()
        {
            if(_PanelStack != null && _PanelStack.Count >= 1)
            {
                _PanelStack.Clear();
                return true;
            }
            return false;
        }
	}
}

