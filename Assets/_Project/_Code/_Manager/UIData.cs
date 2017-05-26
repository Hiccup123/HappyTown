using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIForm
{
    public class UIData
    {
        //窗体预设路径（窗体预设名称，窗体预设路径）
        private Dictionary<string, string> _DicFormsPaths;
        public Dictionary<string,string> GetDicFormsPathDic
        {
            get { return _DicFormsPaths; }
        }

        //缓存所有的UI窗体
        private Dictionary<string, BaseUIForms> _DicALLUIForms;
        public Dictionary<string,BaseUIForms> GetAllUIFormsDic
        {
            get { return _DicALLUIForms; }
        }

        //当前显示的UI窗体
        private Dictionary<string, BaseUIForms> _DicCurrentShowUIForms;
        public Dictionary<string,BaseUIForms> GetCurrentShowUIFormsDic
        {
            get { return _DicCurrentShowUIForms; }
        }

        //当前顺序打开的UI窗体集合
        private Stack<BaseUIForms> _StaCurrentUIForms;

        public UIData ()
        {
            //字段初始化
            _DicALLUIForms = new Dictionary<string, UIForm.BaseUIForms>();
            _DicCurrentShowUIForms = new Dictionary<string, BaseUIForms>();
            _DicFormsPaths = new Dictionary<string, string>();
            _StaCurrentUIForms = new Stack<BaseUIForms>();

            InItUIFormsPathsData();
        }

        //初始化“UI窗体预设”路径数据
        private void InItUIFormsPathsData()
        {
            IConfig pathConfig = new ConfigByJson(SysDefine.SYS_UI_PATH_CONFIG);
            if (pathConfig != null)
            {
                _DicFormsPaths = pathConfig.AppSetDic;
            }
        }

        #region Enter Or Exit Method
        /// <summary>
        /// 把当前窗体加载到“当前窗体”集合中
        /// </summary>
        /// <param name="uiFormName">窗体预设的名称</param>
        public void EnterUIFormsCache(string uiFormName)
        {
            BaseUIForms baseUIForm;     //UI窗体基类

            //如果“正在显示”的集合中，存在整个UI窗体，则直接返回
            _DicCurrentShowUIForms.TryGetValue(uiFormName, out baseUIForm);
            if (baseUIForm != null) return;

            //把当前窗体加载到“正在显示”集合中
            _DicALLUIForms.TryGetValue(uiFormName, out baseUIForm);
            if (baseUIForm != null)
            {
                _DicCurrentShowUIForms.Add(uiFormName, baseUIForm);
                baseUIForm.Display();        //显示当前窗体
            }
        }

        /// <summary>
        /// 卸载UI窗体从“当前显示窗体集合”缓存中
        /// </summary>
        /// <param name="uiFormsName"></param>
        public void ExitUIFormsCache(string uiFormsName)
        {
            BaseUIForms baseUIForms;

            _DicCurrentShowUIForms.TryGetValue(uiFormsName, out baseUIForms);
            if (baseUIForms == null) return;

            baseUIForms.Hiding();
            _DicCurrentShowUIForms.Remove(uiFormsName);
        }

        /// <summary>
        /// UI窗体入栈
        /// 功能 1：判断栈里是否已经有窗体，有则“冻结”
        ///      2：先判断“UI预设缓存集合”是否有指定的UI窗体，有则处理
        ///      3：指定UI窗体入“栈”
        /// </summary>
        /// <param name="uiFormsName"></param>
        public void PushUIForms(string uiFormsName)
        {
            BaseUIForms baseUI;

            //判断栈里是否已经有窗体，有则“冻结”
            if (_StaCurrentUIForms.Count > 0)
            {
                BaseUIForms topUIForms = _StaCurrentUIForms.Peek();
                topUIForms.Freeze();
            }

            //先判断“UI预设缓存集合”是否有制定的UI窗体，有则处理
            _DicALLUIForms.TryGetValue(uiFormsName, out baseUI);
            if (baseUI != null)
            {
                baseUI.Display();
            }
            else
            {
                Debug.LogError("baseUI == null ! Check uiFormsName : " + uiFormsName);
                return;
            }

            //指定UI窗体入“栈”
            _StaCurrentUIForms.Push(baseUI);
        }

        /// <summary>
        /// UI窗体出栈
        /// </summary>
        public void PopUIForms(string uiFormName)
        {
            if (_StaCurrentUIForms.Count >= 2)
            {
                //出栈
                BaseUIForms topUIForms = _StaCurrentUIForms.Pop();
                topUIForms.Hiding();

                //下个窗体重新显示
                BaseUIForms nextUIForms = _StaCurrentUIForms.Peek();
                nextUIForms.ReDisplay();
            }
            else if (_StaCurrentUIForms.Count == 1)
            {
                BaseUIForms topUIForms = _StaCurrentUIForms.Pop();
                topUIForms.Hiding();
            }
        }

        /// <summary>
        /// 加载UI窗体到“当前显示窗体集合”缓存中，且隐藏其他正在显示的页面
        /// </summary>
        /// <param name="uiFormsName"></param>
        public void EnterUIFormsToCacheHideOther(string uiFormsName)
        {
            BaseUIForms baseUIForms;
            BaseUIForms baseUIFormsFromAllCache;

            _DicCurrentShowUIForms.TryGetValue(uiFormsName, out baseUIForms);
            if (baseUIForms != null) return;

            //“正在显示UI窗体缓存”与“栈缓存”集合里所有窗体进行隐藏
            foreach (BaseUIForms baseUIFormsItem in _DicCurrentShowUIForms.Values)
            {
                baseUIFormsItem.Hiding();
            }
            foreach (BaseUIForms baseUIFormsItem in _StaCurrentUIForms)
            {
                baseUIFormsItem.Hiding();
            }

            //把当前窗体加载到“正在显示UI窗体缓存”集合里
            _DicALLUIForms.TryGetValue(uiFormsName, out baseUIFormsFromAllCache);
            if (baseUIFormsFromAllCache != null)
            {
                _DicCurrentShowUIForms.Add(uiFormsName, baseUIFormsFromAllCache);
                baseUIFormsFromAllCache.Display();
            }
        }

        /// <summary>
        /// 卸载UI窗体从“当前显示窗体集合”缓存中，且显示其他原本需要显示的页面
        /// </summary>
        /// <param name="uiFormsName"></param>
        public void ExitUIFormsFromCacheAndShowOther(string uiFormsName)
        {
            BaseUIForms baseUIForms;

            _DicCurrentShowUIForms.TryGetValue(uiFormsName, out baseUIForms);
            if (baseUIForms != null) return;

            baseUIForms.Hiding();
            _DicCurrentShowUIForms.Remove(uiFormsName);

            foreach (BaseUIForms baseUIFormsItem in _DicCurrentShowUIForms.Values)
            {
                baseUIFormsItem.ReDisplay();
            }
            foreach (BaseUIForms baseUIFormsItem in _StaCurrentUIForms)
            {
                baseUIFormsItem.ReDisplay();
            }
        }
        #endregion

        /// <summary>
        /// 清空“栈”结构体集合
        /// </summary>
        /// <returns></returns>
        public bool ClearStackArray()
        {
            if (_StaCurrentUIForms != null && _StaCurrentUIForms.Count >= 1)
            {
                _StaCurrentUIForms.Clear();
                return true;
            }
            return false;
        }

        #region TryGetValue
        /// <summary>
        /// 判断UI窗体路径是否存在
        /// </summary>
        /// <param name="uiFormName"></param>
        /// <param name="outPath"></param>
        /// <returns></returns>
        public bool TryGetValueFormPathDic (string uiFormName, out string outPath)
        {
            //Debug.Log("out:" + _DicFormsPaths.TryGetValue(uiFormName, out outPath) + "|||||outPath:" + outPath);
            return _DicFormsPaths.TryGetValue(uiFormName,out outPath);
        }

        /// <summary>
        /// 判断UI窗体是否存在于缓存的所有UI窗体集中
        /// </summary>
        /// <param name="uiFormName"></param>
        /// <param name="uiForms"></param>
        /// <returns></returns>
        public bool TryGetValueFormALLUIDic(string uiFormName, out BaseUIForms uiForms)
        {
            return _DicALLUIForms.TryGetValue(uiFormName, out uiForms);
        }

        /// <summary>
        /// 判断UI窗体是否存在于缓存的当前显示UI窗体集中
        /// </summary>
        /// <param name="uiFormName"></param>
        /// <param name="uiForms"></param>
        /// <returns></returns>
        public bool TryGetValueFormCurrentShowUIDic(string uiFormName, out BaseUIForms uiForms)
        {
            return _DicCurrentShowUIForms.TryGetValue(uiFormName, out uiForms);
        }
        #endregion

        #region Add BaseUIForm
        /// <summary>
        /// 添加UI窗体
        /// </summary>
        /// <param name="uiFormName"></param>
        /// <param name="uiForm"></param>
        public void AddUIFormToDic(Dictionary<string,BaseUIForms> uiFormsDic,string uiFormName,BaseUIForms uiForm)
        {
            if(!uiFormsDic.ContainsKey(uiFormName))
            {
                uiFormsDic.Add(uiFormName,uiForm);
            }
            else
            {
                uiFormsDic[uiFormName] = uiForm;
            }
        }
        #endregion
    }
}

