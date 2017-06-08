using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFW
{
    public class ResourcesMgr : Singleton<ResourcesMgr>
    {
        private Hashtable hTable = null;

        void Awake()
        {
            hTable = new Hashtable();
        }

        /// <summary>
        /// 调用资源
        /// </summary>
        /// <param name="path"></param>
        /// <param name="isCatch"></param>
        /// <returns></returns>
        public GameObject LoadAsset(string path, bool isCatch)
        {
            GameObject resourceObj = LoadResource<GameObject>(path, isCatch);
            GameObject cloneObj = GameObject.Instantiate<GameObject>(resourceObj);
            if(cloneObj == null)
            {
                Debug.LogError(GetType() + " 克隆资源失败，请检查 path = " + path);
            }

            return cloneObj;
        }

        /// <summary>
        /// 获取资源
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="isCatch"></param>
        /// <returns></returns>
        public T LoadResource<T>(string path,bool isCatch) where T : UnityEngine.Object
        {
            if(hTable.Contains(path))
            {
                return hTable[path] as T;
            }

            T tResource = Resources.Load<T>(path);
            if (tResource == null)
            {
                Debug.LogError(GetType() + "/ tResource 提取不到资源，请检查 path = " + path);
            }
            else if(isCatch)
            {
                hTable.Add(path, tResource);
            }

            return tResource;
        }
    }
}

