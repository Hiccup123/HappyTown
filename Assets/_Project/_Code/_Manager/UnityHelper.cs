using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityHelper : MonoBehaviour
{
    public static bool IsFirstLoad = true;      //是否第一次load

    //Get Dont Destroy Obj
    public static GameObject GetDontDestroyOnLoadGameObject()
    {
        return GameObject.FindGameObjectWithTag(UIForm.SysDefine.SYS_DONT_DESTROY);
    }

    /// <summary>
    /// 查找子节点
    /// 使用递归算法
    /// </summary>
    /// <param name="rootTrans">父对象</param>
    /// <param name="name">目标名称</param>
    /// <returns></returns>
    public static Transform FindTheChild(GameObject rootObj, string name)
    {
        Transform targetTrans = null;

        targetTrans = rootObj.transform.Find(name);
        if (targetTrans == null)
        {
            foreach (Transform trans in rootObj.transform)
            {
                targetTrans = FindTheChild(trans.gameObject, name);
                if (targetTrans != null)
                {
                    return targetTrans;
                }
            }
        }
        return targetTrans;
    }

    /// <summary>
    /// 为目标设置父对象
    /// </summary>
    /// <param name="targetTrans">目标</param>
    /// <param name="rootTrans">父对象</param>
    /// <param name="flag"></param>
    public static void AddChildToParent(Transform targetTrans, Transform rootTrans, bool flag = false)
    {
        targetTrans.SetParent(rootTrans, flag);
        targetTrans.localPosition = Vector3.zero;
        targetTrans.localScale = Vector3.one;
        targetTrans.localEulerAngles = Vector3.zero;
    }

    #region GetChildNodeComponentScript
    /// <summary>
    /// 获取子节点脚本组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="rootTrans"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static T GetChildNodeComponentScript<T>(GameObject rootObj, string name) where T : Component
    {
        Transform targetTransNode = null;

        targetTransNode = FindTheChild(rootObj, name);
        if (targetTransNode != null)
        {
            return targetTransNode.gameObject.GetComponent<T>();
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 子节点添加脚本
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="rootObj"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static T AddChildNodeComponentScripte<T>(GameObject rootObj, string name) where T : Component
    {
        Transform targetTrans = null;

        targetTrans = FindTheChild(rootObj, name);
        if (targetTrans != null)
        {
            T[] componentsArrary = targetTrans.GetComponents<T>();
            for (int i = 0; i < componentsArrary.Length; i++)
            {
                if (componentsArrary[i] != null)
                {
                    Destroy(componentsArrary[i]);
                }
            }

            return targetTrans.gameObject.AddComponent<T>();
        }
        else
        {
            return null;
        }
    }

    #endregion
}
