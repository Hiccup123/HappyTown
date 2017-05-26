using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace TestMVC
{
    public class TestCommand : SimpleCommand
    {
        public new const string NAME = "TestCommand";

        public override void Execute(INotification notification)
        {
            Debug.Log("Execute");
            TestProxy proxy = (TestProxy)Facade.RetrieveProxy(TestProxy.NAME);
            proxy.ChangeLevel(1);
        }
    }
}

