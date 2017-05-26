using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIForm;

public class MainUIForm : BaseUIForms {

	void Awake ()
    {
        //CurrentUIType.I_ShowMode = new ReverseChangeMode();
        CurrentUIType.UIForms_Type = UIFormType.Fixed;
    }


}
