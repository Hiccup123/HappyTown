using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool applicationIsQuitting;
    public static bool ApplicationIsQuitting
    {
        get { return applicationIsQuitting; }
    }

    private static readonly object temp = new object();

    private static T _instance;

    public static T GetInstanceWinthOutCreate()
    {
        return _instance;
    }

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                //lock to sure only _instance once
                lock (temp)
                {
                    //another thread may wait outside the lock while this thread goes into lock and instanced singleton,
                    //so check null again when enter into lock.
                    if (_instance == null)
                    {
                        _instance = (T)FindObjectOfType(typeof(T));

                        if (FindObjectsOfType(typeof(T)).Length > 1)
                        {
                            Debug.LogError("[Singleton] Something went really wrong\n" +
                                " - there should never be more than 1 singleton!\n" +
                                "Reopenning the scene might fix it.");

                            return _instance;
                        }

                        var singleton = UnityHelper.GetDontDestroyOnLoadGameObject();
                        string instanceName = typeof(T).ToString().Substring(typeof(T).ToString().IndexOf('.') + 1);
                        GameObject instanceObj = new GameObject("_" + instanceName);
                        UnityHelper.AddChildToParent(instanceObj.transform, singleton.transform);
                        _instance = instanceObj.AddComponent<T>();
                    }
                }
            }

            return _instance;
        }
    }

    public void OnDestroy()
    {
        _instance = null;
    }

    /// <summary>
    /// When Unity quits, it destroys objects in a random order.
    /// In principle, a Singleton is only destroyed when application quits.
    /// If any script calls Instance after it have been destroyed, 
    /// it will create a buggy ghost object that will stay on the Editor scene
    /// even after stopping playing the Application. Really bad!
    /// So, this was made to be sure we're not creating that buggy ghost object.
    /// 
    /// </summary>
    /// 
    /// Instance will be destroyed manually in our game.
    public void OnApplicationQuit()
    {
        applicationIsQuitting = true;
    }
}

