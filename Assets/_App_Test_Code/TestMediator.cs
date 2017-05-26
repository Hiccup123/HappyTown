using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using UnityEngine.UI;
using PureMVC.Interfaces;

namespace TestMVC
{
    public class TestMediator : Mediator
    {
        public new const string NAME = "TestMediator";

        private Text levelText;
        private Button levelUpBtn;

        public TestMediator(GameObject root) : base(NAME)
        {
            levelText = GameUtility.GetChildComponent<Text>(root, "LevelText");
            levelUpBtn = GameUtility.GetChildComponent<Button>(root, "LevelUpBtn");

            levelUpBtn.onClick.AddListener(OnClickLevelUpBtn);
        }

        private void OnClickLevelUpBtn()
        {
            Debug.Log("NotificationConstant.LevelUp");
            SendNotification(NotificationConstant.LevelUp);
        }

        public override IList<string> ListNotificationInterests()
        {
            Debug.Log("ListNotificationInterests   ：  LevelChange");
            IList<string> list = new List<string>();
            list.Add(NotificationConstant.LevelChange);
            return list;
        }

        public override void HandleNotification(INotification notification)
        {
            switch(notification.Name)
            {
                case NotificationConstant.LevelChange:
                    Debug.Log("notification.Body:" + notification.Body);
                    CharacterInfo info = notification.Body as CharacterInfo;
                    Debug.Log("info:" + info);
                    levelText.text = info.Level.ToString();
                    break;
                case NotificationConstant.LevelUp:
                    break;
                default:
                    break;
            }
        }
    }
}

