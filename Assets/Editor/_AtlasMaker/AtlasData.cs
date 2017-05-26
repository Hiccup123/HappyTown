/***
* 功 能： 打包图集
* 描 述： 
*
* 日 期：5/25/2017
* ───────────────────────────────────
* 版 本：v1.0         作 者：LL
*
* Unity版本：5.5.0f3
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtlasData : MonoBehaviour
{
    public Texture2D _AtlasTexture;         //表示工具生成的纹理图集

    public string[] _TextureNames;          //由各纹理文件名组成的字符串数组

    public Rect[] _UVs;
}

