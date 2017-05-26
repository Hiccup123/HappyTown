using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

namespace TestMVC
{
    public class TestProxy : Proxy
    {
        public new const string NAME = "TestProxy";
        public CharacterInfo data { get; set; }

        public TestProxy() : base(NAME)
        {
            data = new CharacterInfo(1,1);
        }

        public void ChangeLevel(int change)
        {
            data.Level += change;
            Debug.Log("NotificationConstant.LevelChange ： ChangeLevel  ：  " + data.Level);
            SendNotification(NotificationConstant.LevelChange, data);
        }
    }
}

