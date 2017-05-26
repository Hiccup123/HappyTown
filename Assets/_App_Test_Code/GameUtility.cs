using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestMVC
{
    public class GameUtility
    {
        public static Transform GetChild(GameObject root, string path)
        {
            Transform trans = root.transform.Find(path);

            return trans;
        }

        public static T GetChildComponent<T>(GameObject root, string path) where T : Component
        {
            Transform trans = root.transform.Find(path);

            T t = trans.GetComponent<T>();
            return t;
        }
    }
}

