using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIForm
{
    //UI窗体（位置）类型
    public enum UIFormType
    {
        Normal,     //普通窗体
        Fixed,      //固定窗体
        PopUp,      //弹出窗体
    }

    //UI窗体透明度类型
    public enum UIFormLucenyType
    {
        Lucency,        //完全透明，不能穿透
        Translucence,       //半透明，不能穿透
        ImPenetrable,       //低透明度，不能穿透
        Pentrate,       //可以穿透
    }

    public class UIType
    {
        //是否需要清空“反向切换”
        public bool IsClearReverseChange = false;

        //UI窗体类型
        public UIFormType UIForms_Type = UIFormType.Normal;
  
        public IShowMode I_ShowMode = new NormalShowMode();

        //UI窗体透明度类型
        public UIFormLucenyType UIForms_LucencyType = UIFormLucenyType.Lucency;
    }
}
