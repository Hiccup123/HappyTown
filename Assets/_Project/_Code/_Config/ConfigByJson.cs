using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UIForm
{
    public class ConfigByJson : IConfig
    {
        private Dictionary<string, string> _AppSetDic;

        /// <summary>
        /// 只读，得到应用设置
        /// </summary>
        public Dictionary<string,string> AppSetDic
        {
            get { return _AppSetDic; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="jsonPath">json文件路径</param>
        public ConfigByJson(string jsonPath)
        {
            _AppSetDic = new Dictionary<string, string>();
            AnalysisJson(jsonPath);
        }

        /// <summary>
        /// 得到AppSetDic.MaxCount
        /// </summary>
        /// <returns></returns>
        public int GetAppSetMaxNum()
        {
            if(_AppSetDic != null && _AppSetDic.Count >= 1)
            {
                return _AppSetDic.Count;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 初始化解析json数据
        /// </summary>
        /// <param name="jsonPath"></param>
        private void AnalysisJson(string jsonPath)
        {
            TextAsset info = null;
            KeyValuesInfo keyValueInfo = null;
            //Debug.Log("jsonPath:" + jsonPath);
            if (string.IsNullOrEmpty(jsonPath)) return;

            try
            {
                info = Resources.Load<TextAsset>(jsonPath);
                //Debug.Log("info:" + info.text);
                keyValueInfo = JsonUtility.FromJson<KeyValuesInfo>(info.text);
            }
            catch
            {
                throw new JsonAnalysisExp(GetType() + "/Analysis()/Json Analysis Exception ! Parameter jsonPath = " + jsonPath);
            }

            foreach(KeyValueNode nodeInfo in keyValueInfo.ConfigList)
            {
                //Debug.Log("Key:" + nodeInfo.Key + "    ||Value:" + nodeInfo.Value);
                _AppSetDic.Add(nodeInfo.Key, nodeInfo.Value);
            }
        }
    }
}

