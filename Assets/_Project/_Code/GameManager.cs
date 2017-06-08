using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFW;

public class GameManager : MonoBehaviour {
    
    void Start ()
    {
        //LogSystem.WriteData(GetType() + "/Start()/");
        //LogSystem.SyncLogCatchToFile();

        UIFormManager.Instance.ShowUIForm("MainUIForm");
        UIFormManager.Instance.ShowUIForm("FightUIForm");
        //PoolManager.Instance.RequestObj(Resources.Load("_Prefabs/_UIPrefabs/Canvas") as GameObject);
	}
}
