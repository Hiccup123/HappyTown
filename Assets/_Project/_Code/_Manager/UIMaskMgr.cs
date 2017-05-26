/*
 *  Title : "UIForm" UI框架
 *          主题 : UI遮罩管理器
 *  Description : 
 *          功能 : 负责“弹出窗体”模态显示实现
 *          
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIForm
{
    public class UIMaskMgr : Singleton<UIMaskMgr>
    {
        //UI根节点对象
        private GameObject _GoCanvasRoot = null;
        //顶层面板
        private GameObject _GoTopPanel;
        //遮罩面板
        private GameObject _GoMaskPanel;
        //UI摄像机
        private Camera _UICamera;
        //UI摄像机原始的“层深”
        private float _OriginalUICameraDepth;

        void Awake()
        {
            _GoCanvasRoot = GameObject.FindGameObjectWithTag(SysDefine.SYS_TAG_CANVAS);

            //分别得到“顶层面板”、“遮罩面板”
            _GoTopPanel = _GoCanvasRoot;
            _GoMaskPanel = UnityHelper.FindTheChild(_GoCanvasRoot, SysDefine.SYS_UI_MASK_PANEL).gameObject;

            //_UICamera = GameObject.FindGameObjectWithTag("_TagUICamera").GetComponent<Camera>();
            _UICamera = UnityHelper.FindTheChild(_GoCanvasRoot, SysDefine.SYS_UI_CAMERA).GetComponent<Camera>();
            if(_UICamera != null)
            {
                _OriginalUICameraDepth = _UICamera.depth;
            }
        }

        /// <summary>
        /// 设置遮罩状态
        /// </summary>
        /// <param name="goDisplayUIForms">需要显示的UI窗体</param>
        /// <param name="lucenyType">显示透明度属性</param>
        public void SetMaskWindow(GameObject goDisplayUIForms,UIFormLucenyType lucenyType = UIFormLucenyType.Lucency)
        {
            //顶层窗体下移
            _GoTopPanel.transform.SetAsFirstSibling();
            Color newColor = new Color();

            switch (lucenyType)
            {
                case UIFormLucenyType.Lucency:              //完全透明，不能穿透
                    _GoMaskPanel.SetActive(true);
                    newColor = new Color(255 / 255f, 255 / 255f, 255 / 255f, 0 / 255f);
                    break;
                case UIFormLucenyType.Translucence:
                    _GoMaskPanel.SetActive(true);
                    newColor = new Color(220 / 255f, 220 / 255f, 220 / 255f, 50 / 255f);
                    break;
                case UIFormLucenyType.ImPenetrable:
                    _GoMaskPanel.SetActive(true);
                    newColor = new Color(50 / 255f, 50 / 255f, 50 / 255f, 200 / 255f);
                    break;
                case UIFormLucenyType.Pentrate:
                    if(_GoMaskPanel.activeInHierarchy)
                    {
                        _GoMaskPanel.SetActive(false);
                    }
                    break;
                default:
                    break;
            }

            _GoMaskPanel.GetComponent<Image>().color = newColor;

            //遮罩窗体下移
            _GoMaskPanel.transform.SetAsLastSibling();
            //显示窗体下移
            goDisplayUIForms.transform.SetAsLastSibling();

            if(_UICamera != null)
            {
                _UICamera.depth += 100;
            }
        }

        /// <summary>
        /// 取消遮罩状态
        /// </summary>
        public void CancelMaskWindow()
        {
            _GoTopPanel.transform.SetAsFirstSibling();

            if(_GoMaskPanel.activeInHierarchy)
            {
                _GoMaskPanel.SetActive(false);
            }

            if(_UICamera != null)
            {
                _UICamera.depth = _OriginalUICameraDepth;       //恢复层深
            }
        }
    }
}

