/***
* 功 能： N/A
* 描 述： 
*
* 日 期：6/8/2017
* ───────────────────────────────────
* 版 本：v1.0         作 者：LL
*
* Unity版本：5.5.0f3
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainCity
{
	public class Worker : MonoBehaviour {

        public int StationID;       //工位号

        public IAction CurAction;       //当前状态

        private List<IAction> _ActionList = new List<IAction>();

        private ActionData _ActionData;

        private void Awake()
        {
            _ActionData = new ActionData();
        }

        private void Start()
        {
            RegisterAction(new Idle());
        }

        //注册执行动作
        public void RegisterAction(IAction action)
        {
            if(!_ActionList.Contains(action))
            {
                _ActionList.Add(action);
            }
        }

        //注销执行动作
        public void UnRegisterAction(IAction action)
        {
            if(_ActionList.Contains(action))
            {
                _ActionList.Remove(action);
            }
        }

        //清空执行动作
        public void ClearAction()
        {
            _ActionList.Clear();
        }

        public void ExcuteCurAction()
        {
            CurAction.Excute();
        }
	}
}

