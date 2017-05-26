using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIForm
{
    public interface IShowMode
    {
        void EnterShowMode(UIData data,string name);
        void ExitShowMode(UIData data,string name);
    }

    /*  普通  */
    public class NormalShowMode : IShowMode
    {
        public void EnterShowMode(UIData data,string name)
        {
            //Debug.Log("Default");
            data.EnterUIFormsCache(name);
        }

        public void ExitShowMode(UIData data,string name)
        {
            data.ExitUIFormsCache(name);
        }
    }

    /*  反向切换  */
    public class ReverseChangeMode : IShowMode
    {
        public void EnterShowMode(UIData data, string name)
        {
            //Debug.Log("ReverseChangeMode");
            data.PushUIForms(name);
        }

        public void ExitShowMode(UIData data, string name)
        {
            data.PopUIForms(name);
        }
    }

    /*  隐藏其他  */
    public class HideOtherMode : IShowMode
    {
        public void EnterShowMode(UIData data, string name)
        {
            data.EnterUIFormsToCacheHideOther(name);
        }

        public void ExitShowMode(UIData data, string name)
        {
            data.ExitUIFormsFromCacheAndShowOther(name);
        }
    }
}
