using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

namespace UIForm
{
    public static class LogSystem
    {
        /*  核心字段    */
        private static List<string> _LogArray;      //日志缓存数据
        private static string _LogPath = null;      //Log日志文件路径
        private static State _LogState;             //Log日志状态（部署模式）
        private static int _LogMaxCapacity;         //Log日志最大容量
        private static int _LogBufferMaxNum;        //Log日志缓存最大容量

        /*  Json配置文件“标签常量”  */
        private const string Json_Config_Log_DriveName = "LogDriveName";
        private const string Json_Config_Log_Path = "LogPath";
        private const string Json_Config_Log_State = "LogState";
        private const string Json_Config_Log_MaxCapacity = "LogMaxCapacity";
        private const string Json_Config_Log_BufferNum = "LogBufferNum";

        /*  日志状态常量（部署模式）    */
        private const string Json_Config_Log_State_Develop = "Develop";
        private const string Json_Config_Log_State_Special = "Special";
        private const string Json_Config_Log_State_Deploy = "Deploy";
        private const string Json_Config_Log_State_Stop = "Stop";

        //日志默认路径
        private static string Json_Config_Log_Default_Path = "DungeonFighterLog.txt";
        //日志默认最大容量
        private static int Log_Default_MaxCacityNum = 2000;
        //日志缓存默认最大容量
        private static int Log_Default_MaxLogBufferNum = 1;
        //日志提示信息
        private static string Log_Improt_Tips = "@Important!!!";
        private static string Log_Warrning_Tips = "Warrning";

        private static string _Cur_LogState = null;         //日志状态（部署模式）
        private static string _Cur_LogMaxCapacity = null;   //日志最大容量
        private static string _Cur_LogBufferNum = null;     //日志缓存最大容量

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static LogSystem()
        {
            _LogArray = new List<string>();

            IConfig config = new ConfigByJson(SysDefine.SYS_LOG_PATH_CONFIG);

            //Pc与编辑器环境下的路径，使用配置文件
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
            _LogPath = config.AppSetDic[Json_Config_Log_DriveName] + ":\\" + config.AppSetDic[Json_Config_Log_Path] + ".txt";
            //Debug.Log("_LogPath:" + _LogPath);
#endif

            _Cur_LogState = config.AppSetDic[Json_Config_Log_State];
            _Cur_LogMaxCapacity = config.AppSetDic[Json_Config_Log_MaxCapacity];
            _Cur_LogBufferNum = config.AppSetDic[Json_Config_Log_BufferNum];

            if(string.IsNullOrEmpty(_LogPath))
            {
                _LogPath = UnityEngine.Application.persistentDataPath + "//" + Json_Config_Log_Default_Path;
            }

            //日志状态（部署模式）
            if(!string.IsNullOrEmpty(_Cur_LogState))
            {
                switch(_Cur_LogState)
                {
                    case Json_Config_Log_State_Develop:
                        _LogState = State.Develop;
                        break;
                    case Json_Config_Log_State_Special:
                        _LogState = State.Special;
                        break;
                    case Json_Config_Log_State_Deploy:
                        _LogState = State.Deploy;
                        break;
                    case Json_Config_Log_State_Stop:
                        _LogState = State.Stop;
                        break;
                    default:
                        _LogState = State.Stop;
                        break;
                }
            }
            else
            {
                _LogState = State.Stop;
            }

            _LogMaxCapacity = !string.IsNullOrEmpty(_Cur_LogMaxCapacity) ? Convert.ToInt32(_Cur_LogMaxCapacity) : Log_Default_MaxCacityNum;

            _LogBufferMaxNum = !string.IsNullOrEmpty(_Cur_LogBufferNum) ? Convert.ToInt32(_Cur_LogBufferNum) : Log_Default_MaxLogBufferNum;
        }

        /// <summary>
        /// 将数据写入文件中
        /// </summary>
        /// <param name="writeFileData">写入的调试信息</param>
        /// <param name="level">级别</param>
        public static void WriteData(string writeFileData,Level level)
        {
            if (_LogState == State.Stop) return;

            //超过指定容量清空
            if(_LogArray.Count >= _LogMaxCapacity)
            {
                _LogArray.Clear();
            }

            if(!string.IsNullOrEmpty(writeFileData))
            {
                //增加日期与时间
                writeFileData = _LogState.ToString() + "|" + DateTime.Now.ToShortTimeString() + "|   " + writeFileData + "\r\n";

                if(level == Level.High)
                {
                    writeFileData = Log_Improt_Tips + writeFileData;
                }
                else if(level == Level.Special)
                {
                    writeFileData = Log_Warrning_Tips + writeFileData;
                }

                switch(_LogState)
                {
                    case State.Develop:
                        AppendDataToFile(writeFileData);
                        break;
                    case State.Special:
                        if(level == Level.High || level == Level.Special)
                        {
                            AppendDataToFile(writeFileData);
                        }
                        break;
                    case State.Deploy:
                        if(level == Level.High)
                        {
                            AppendDataToFile(writeFileData);
                        }
                        break;
                    case State.Stop:
                        break;
                    default:
                        break;
                }
            }
        }

        public static void WriteData(string writeFileData)
        {
            WriteData(writeFileData, Level.Low);
        }

        /// <summary>
        /// 追加数据到文件
        /// </summary>
        /// <param name="writeFileData"></param>
        private static void AppendDataToFile(string writeFileData)
        {
            if(!string.IsNullOrEmpty(writeFileData))
            {
                //调试信息数据追加到缓存集合中
                _LogArray.Add(writeFileData);
            }

            if(_LogArray.Count % _LogBufferMaxNum == 0)
            {
                //同步缓存数据信息到实体文件中
                SyncLogCatchToFile();
            }
        }

        /// <summary>
        /// 创建文件与写入文件
        /// </summary>
        /// <param name="pathAndName"></param>
        /// <param name="info"></param>
        private static void CreateFile(string pathAndName,string info)
        {
            FileInfo fi = new FileInfo(pathAndName);
            StreamWriter sw = !fi.Exists ? fi.CreateText() : fi.AppendText();       //文件不存在则创建，否则打开

            sw.WriteLine(info); //行形式写入
            sw.Close();         //关闭流
            sw.Dispose();       //销毁流
        }

        #region Important Method

        /// <summary>
        /// 查询日志缓存中的内容
        /// </summary>
        /// <returns>返回缓存中的查询内容</returns>
        public static List<string> QueryAllDataFromLogBuffer()
        {
            return _LogArray == null ? null : _LogArray;
        }

        /// <summary>
        /// 查询日志缓存中实际数量个数
        /// </summary>
        /// <returns>返回-1表示查询失败</returns>
        public static int QueryLogBufferNum()
        {
            return _LogArray == null ? -1 : _LogArray.Count;
        }

        /// <summary>
        /// 清空日志缓存中所有数据
        /// </summary>
        public static void ClearLogBufferAllData()
        {
            if(_LogArray != null)
            {
                _LogArray.Clear();
            }
        }

        /// <summary>
        /// 同步缓存数据信息到实体文件中
        /// </summary>
        public static void SyncLogCatchToFile()
        {
            if(!string.IsNullOrEmpty(_LogPath))
            {
                foreach(string item in _LogArray)
                {
                    CreateFile(_LogPath, item);
                }

                //清楚日志缓存中所有数据
                ClearLogBufferAllData();
            }
        }

        #endregion
    }

    /// <summary>
    /// 日志状态
    /// </summary>
    public enum State
    {
        Develop,        //开发模式（输出所有日志内容）
        Special,        //指定输出模式
        Deploy,         //部署模式（只输出最核心日志信息，例如严重错误信息，用户登录账号等）
        Stop,           //停止输出模式（不输出任何日志信息）
    }

    /// <summary>
    /// 调试信息的等级（表示调试信息本身的重要程度
    /// </summary>
    public enum Level
    {
        High,
        Special,
        Low,
    }
}

