using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFW;

public class MainUIForm : BaseUIForms {

	void Awake ()
    {
        //CurrentUIType.I_ShowMode = new ReverseChangeMode();
        CurrentUIType.UIForms_Type = UIFormType.Normal;
    }

    public void OnClickItem()
    {
        Debug.Log("Group");
    }
}
