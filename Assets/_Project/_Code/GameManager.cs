using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIForm;

public class GameManager : MonoBehaviour {
    
    void Start ()
    {
        //LogSystem.WriteData(GetType() + "/Start()/");
        //LogSystem.SyncLogCatchToFile();
       
        UIManager.Instance.ShowUIForm("MainUIForm");
        //PoolManager.Instance.RequestObj(Resources.Load("_Prefabs/_UIPrefabs/Canvas") as GameObject);
	}
}
