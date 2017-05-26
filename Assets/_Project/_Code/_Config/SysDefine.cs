using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIForm
{
    public class SysDefine
    {
        /*  全局脚本挂载对象标签  */
        public static string SYS_DONT_DESTROY = "SYS_DONT_DESTROY";
        /*  根节点标签  */
        public static string SYS_TAG_CANVAS = "SYS_TAG_CANVAS";                 
        /*  节点常量    */
        public static string SYS_CANVAS_NORMAL_NODE_NAME = "Normal";            //全屏节点
        public static string SYS_CANVAS_FIXED_NODE_NAME = "Fixed";              //固定节点
        public static string SYS_CANVAS_POPUP_NODE_NAME = "PopUp";              //弹出节点

        /*  遮罩  */
        public const string SYS_UI_MASK_PANEL = "_UIMaskPanel";
        /*  根节点摄像机  */
        public const string SYS_UI_CAMERA = "UICamera";

        /*  路径常量   */
        public static string SYS_PATH_CANVAS = "_Prefabs/_UIPrefabs/Canvas";        //根节点
        public const string SYS_LOG_PATH_CONFIG = "_Config/SysConfig";              //日志config路径
        public const string SYS_UI_PATH_CONFIG = "_Config/UIPathConfig";            //UI Config路径
    }
}

