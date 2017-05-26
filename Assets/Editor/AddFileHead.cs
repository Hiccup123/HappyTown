/***
* 功 能：添加头部注释
* 描 述： 
*
* 日 期：2017.5.25
* ───────────────────────────────────
* 版 本：v 1.0         作 者：Leon
*/
using UnityEditor;
using UnityEngine;
using System.IO;

public class AddFileHead : UnityEditor.AssetModificationProcessor
{
    /// <summary>
    /// 此函数在assets被创建完，文件已经生成到磁盘上，但是没有生成.meta文件和import之前被调用
    /// </summary>
    /// <param name="newFileMeta">是由创建文件的path加上.meta组成的</param>
    public static void OnWillCreateAsset(string newFileMeta)
    {
        string newFilePath = newFileMeta.Replace(".meta", "");
        string fileText = Path.GetExtension(newFilePath);

        if(fileText != ".cs")
        {
            return;
        }

        //Application.dataPath会根据使用平台不同而不同
        string realPath = Application.dataPath.Replace("Assets", "") + newFilePath;
        string scriptContent = File.ReadAllText(realPath);

        //自定义规则
        //scriptContent = scriptContent.Replace("#unity_version#", Path.GetFileName(newFilePath));
        scriptContent = scriptContent.Replace("#date#",System.DateTime.Now.ToShortDateString());
        scriptContent = scriptContent.Replace("#author#", "LL");
        scriptContent = scriptContent.Replace("#verson#", "v1.0");
        scriptContent = scriptContent.Replace("#unity_version#", Application.unityVersion);

        File.WriteAllText(realPath,scriptContent);
    }
}

