using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UIFW
{
    public interface IConfig
    {
        /// <summary>
        /// 得到键值对集合数据（只读）
        /// </summary>
        Dictionary<string,string> AppSetDic { get; }

        /// <summary>
        /// 得到配置文件最大数量
        /// </summary>
        /// <returns></returns>
        int GetAppSetMaxNum();
    }

    [Serializable]
    internal class KeyValuesInfo
    {
        public List<KeyValueNode> ConfigList = null;
    }

    [Serializable]
    internal class KeyValueNode
    {
        public string Key = null;

        public string Value = null;
    }
}

