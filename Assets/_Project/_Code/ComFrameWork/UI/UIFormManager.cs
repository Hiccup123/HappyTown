/*
 *      Title:"UIForm"框架
 *             主题:UI管理器
 *      Description:
 *             功能:整个UI框架的核心，用户程序通过调用本类，来调用本框架的大多数功能
 *             功能1:关于入“栈”与出“栈”的UI窗体4个状态的定义逻辑
 *                   入栈状态:
 *                          Freeze();       （上一个UI窗体）冻结
 *                          Display();      （本UI窗体）显示
 *                   出栈状态:
 *                          Hiding();       （本UI窗体）隐藏
 *                          Redisplay();    （上一个UI窗体）重新显示
 *              功能2:增加“非栈”缓存集合
 *              
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFW
{
    public class UIFormManager : Singleton<UIFormManager>
    {
        //UI数据存储
        private UIData uiData;

        //UI根节点
        private Transform _TraCanvasTransform = null;
        //全屏幕显示的节点
        private Transform _TraNormal = null;
        //固定显示的节点
        private Transform _TraFixed = null;
        //弹出节点
        private Transform _TraPopUp = null;

        //初始化核心数据，加载“UI窗体路径”到集合中
        public void Awake()
        {
            uiData = new UIData();

            InItRootCanvasLoading();

            //得到UI根节点、全屏节点、固定节点、弹出节点
            _TraCanvasTransform = GameObject.FindGameObjectWithTag(SysDefine.SYS_TAG_CANVAS).transform;
            _TraNormal = UnityHelper.FindTheChild(_TraCanvasTransform.gameObject, SysDefine.SYS_CANVAS_NORMAL_NODE_NAME);
            _TraFixed = UnityHelper.FindTheChild(_TraCanvasTransform.gameObject, SysDefine.SYS_CANVAS_FIXED_NODE_NAME);
            _TraPopUp = UnityHelper.FindTheChild(_TraCanvasTransform.gameObject, SysDefine.SYS_CANVAS_POPUP_NODE_NAME);

            //“根UI窗体”在场景转换的时候，不允许销毁
            DontDestroyOnLoad(_TraCanvasTransform);
        }

        /// <summary>
        /// 显示（打开）UI窗体
        /// 功能：
        /// 1：根据UI窗体的名称，加载到“所有UI窗体”缓存集合中
        /// 2：根据不同的UI窗体的“显示模式”，分别做不同的加载处理
        /// </summary>
        /// <param name="uiFormName">UI窗体预设名称</param>
        public void ShowUIForm(string uiFormName)
        {
            BaseUIForms baseUIForms = null;     //UI窗体基类

            if (string.IsNullOrEmpty(uiFormName)) return;

            //根据UI窗体的名称，加载到“所有UI窗体”缓存集合中
            baseUIForms = LoadFormsToAllFormsCatch(uiFormName);

            if (baseUIForms == null) return;

            //是否清空“栈”结构体集合
            if(baseUIForms.CurrentUIType.IsClearReverseChange)
            {
                //ClearStackArray();
                uiData.ClearStackArray();
            }

            baseUIForms.CurrentUIType.I_ShowMode.EnterShowMode(uiData, uiFormName);
        }

        /// <summary>
        /// 关闭或返回上一个UI窗体（关闭当前UI窗体）
        /// </summary>
        /// <param name="uiFormsName"></param>
        public void CloseOrReturnUIForms(string uiFormsName)
        {
            BaseUIForms baseUIFroms = null;

            if (string.IsNullOrEmpty(uiFormsName)) return;

            uiData.TryGetValueFormALLUIDic(uiFormsName, out baseUIFroms);
            if (baseUIFroms == null) return;

            baseUIFroms.CurrentUIType.I_ShowMode.ExitShowMode(uiData,uiFormsName);
        }

        #region Private Method
        //资源加载
        private void InItRootCanvasLoading()
        {
            if(UnityHelper.IsFirstLoad)
            {
                ResourcesMgr.Instance.LoadAsset(SysDefine.SYS_PATH_CANVAS, false);
            }
        }

        //初始化加载（根UI窗体）Canvas预设
        private BaseUIForms LoadFormsToAllFormsCatch(string uiFormsName)
        {
            BaseUIForms baseUIResult = null;        //加载的返回UI窗体基类

            uiData.TryGetValueFormALLUIDic(uiFormsName, out baseUIResult);

            if(baseUIResult == null)
            {
                baseUIResult = LoadUIForm(uiFormsName);
            }

            return baseUIResult;
        }

        /// <summary>
        /// 加载指定名称的“UI窗体”
        /// 功能：
        /// 1：根据“UI窗体名称”，加载预设克隆体
        /// 2：根据不同预设克隆体中带的脚本中不同的“位置信息”，加载到“根窗体”下不同的节点
        /// 3：隐藏刚创建的UI克隆体
        /// 4：把克隆体，加入到“所有UI窗体”（缓存）集合中
        /// </summary>
        /// <param name="uiFormName">窗体名称</param>
        /// <returns></returns>
        private BaseUIForms LoadUIForm(string uiFormName)
        {
            string strUIFormPaths = null;       //UI窗体路径
            GameObject goCloneUIPrefabs = null; //创建的UI克隆体预设
            BaseUIForms baseUIForm = null;      //窗体基类

            //根据UI窗体名称，得到对应的加载路径
            uiData.TryGetValueFormPathDic(uiFormName,out strUIFormPaths);
            //Debug.Log("strUIFormPaths:" + strUIFormPaths);
            //根据“UI窗体名称”，加载“预设克隆体”
            if (!string.IsNullOrEmpty(strUIFormPaths))
            {
                goCloneUIPrefabs = ResourcesMgr.Instance.LoadAsset(strUIFormPaths, false);
            }

            //设置“UI克隆体”的父节点（根据克隆体中带的脚本中不同的“位置信息”）
            if(_TraCanvasTransform != null && goCloneUIPrefabs != null)
            {
                baseUIForm = goCloneUIPrefabs.GetComponent<BaseUIForms>();
                if(baseUIForm == null)
                {
                    Debug.Log("baseUIForm == null !,请先确认窗体预设对象上是否加载了baseUIForm的子类脚本！参数uiFormName = " + uiFormName);
                    return null;
                }

                switch (baseUIForm.CurrentUIType.UIForms_Type)
                {
                    case UIFormType.Normal: //普通窗体节点
                        goCloneUIPrefabs.transform.SetParent(_TraNormal, false);
                        break;
                    case UIFormType.Fixed:  //固定窗体节点
                        goCloneUIPrefabs.transform.SetParent(_TraFixed, false);
                        break;
                    case UIFormType.PopUp:  //弹出窗体节点
                        goCloneUIPrefabs.transform.SetParent(_TraPopUp, false);
                        break;
                    default:
                        break;
                }

                //隐藏
                goCloneUIPrefabs.SetActive(false);

                //把克隆体加入到“所有UI窗体”（缓存）集合中
                uiData.AddUIFormToDic(uiData.GetAllUIFormsDic,uiFormName, baseUIForm);
                return baseUIForm;
            }
            else
            {
                Debug.Log("_TraCanvasTransform == " + _TraCanvasTransform + "Or goCloneUIPrefabs == " + goCloneUIPrefabs + "!,Please Check!参数uiFormName = " + uiFormName);
            }

            Debug.Log("出现不可预估的错误，检查参数 uiFormName =" + uiFormName);
            return null;
        }
        #endregion
    }
}

