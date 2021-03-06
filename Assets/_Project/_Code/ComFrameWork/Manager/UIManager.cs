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
	public class UIManager : ManagerBase {

        public static UIManager Instance = null;

        //规定了开发方式，消耗内存换取速度和方便
        private Dictionary<string, GameObject> _SonMemberDic = new Dictionary<string, GameObject>();

        private void Awake()
        {
            Instance = this;
        }

        public void SendMsg<T>(MsgBase<T> tempMsg)
        {
            Debug.Log("tempMsg.GetManager():" + tempMsg.GetManager());
         
            if(tempMsg.GetManager() == ManagerID.UIManager)
            {
                //本模块自己处理
                ProcessEvent(tempMsg);
            }
            else    //MsgCenter
            {
                MsgCenter.Instance.SendToMsg(tempMsg);
            }
        }

        #region SonGameObj manager
        public void RegistGameObject(string name,GameObject obj)
        {
            if(!_SonMemberDic.ContainsKey(name))
            {
                _SonMemberDic.Add(name, obj);
            }
        }

        public void UnRegistGameObject(string name)
        {
            if(!_SonMemberDic.ContainsKey(name))
            {
                _SonMemberDic.Remove(name);
            }
        }
        #endregion

        public T GetObjComponent<T>(string name) where T : Component
        {
            if (_SonMemberDic.ContainsKey(name))
            {
                return _SonMemberDic[name].GetComponent<T>() ?? _SonMemberDic[name].AddComponent<T>();
            }
            Debug.LogError(name + " is null !!!");
            return default(T);
        }
        
        public UIBehaviour GetUIBehaviour(string name)
        {
            return GetObjComponent<UIBehaviour>(name);
        }
    }
}

