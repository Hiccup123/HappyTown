#if UNITY_EDITOR
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
using UnityEditor;

public class AtlasPacker : ScriptableWizard
{

    public Texture2D[] _Textures;                   //指向一系列纹理的指针

    public string _AtlasName = "Atlas_Name";        //纹理图集的名字

    public int _Padding = 4;                        //加入到纹理图集中纹理之间的间隔

    /// <summary>
    /// 
    /// </summary>
    [MenuItem("Tools/AtlasMaker")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Create Atlas", typeof(AtlasPacker));
    }

    private void OnEnable()
    {
        List<Texture2D> textureList = new List<Texture2D>();

        //将编辑器中选择的对象add in list
        if (Selection.objects != null && Selection.objects.Length > 0)
        {
            Object[] objects = EditorUtility.CollectDependencies(Selection.objects);
            foreach (Object obj in objects)
            {
                Texture2D tex = obj as Texture2D;

                if (tex != null)
                {
                    textureList.Add(tex);
                }
            }
        }

        if (textureList.Count > 0)
        {
            _Textures = new Texture2D[textureList.Count];
            for (int i = 0; i < textureList.Count; i++)
            {
                _Textures[i] = textureList[i];
            }
        }
    }

    private void OnWizardCreate()
    {
        GenerateAtlas();
    }

    private void GenerateAtlas()
    {
        if (_Textures == null)
        {
            Debug.LogError("Select 0 texture in project!!!");
            return;
        }

        for(int i = 0;i < _Textures.Length;i ++)
        {
            if(_Textures[i] == null)
            {
                Debug.LogError("_Textures[" + i + "] is null ! Please Check !");
                return;
            }
        }

        //生成图集对象
        GameObject atlasObj = new GameObject("obj_" + _AtlasName);
        AtlasData atlasComponent = atlasObj.AddComponent<AtlasData>();
        atlasComponent._TextureNames = new string[_Textures.Length];

        //配置每一个要加入图集的纹理
        for (int i = 0; i < _Textures.Length; i++)
        {
            //获取纹理资源路径
            string texPath = AssetDatabase.GetAssetPath(_Textures[i]);
            //设置纹理
            ConfigureForAtlas(texPath);
            //将所有纹理名字都加入到列表中
            atlasComponent._TextureNames[i] = texPath;
        }

        //生成纹理图集（PackTextures用于打包多个纹理为一个纹理）
        Texture2D tex2D = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        atlasComponent._UVs = tex2D.PackTextures(_Textures,_Padding, 2048);

        //生成唯一的资源路径
        string assetPath = AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/_Atlas/" + _AtlasName + ".png");
        //把纹理图集保存成文件
        byte[] bytes = tex2D.EncodeToPNG();
        System.IO.File.WriteAllBytes(assetPath, bytes);
        bytes = null;

        //删除生成的纹理图集
        UnityEngine.Object.DestroyImmediate(tex2D);
        //导入纹理资源
        AssetDatabase.ImportAsset(assetPath);
        //获取导入的纹理
        atlasComponent._AtlasTexture = AssetDatabase.LoadAssetAtPath(assetPath, typeof(Texture2D)) as Texture2D;
        //配置纹理图集
        ConfigureForAtlas(AssetDatabase.GetAssetPath(atlasComponent._AtlasTexture));

        assetPath = AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/_Atlas/atlasdata_" + _AtlasName + ".prefab");
        //创建预制对象
        Object prefab = PrefabUtility.CreateEmptyPrefab(assetPath);
        PrefabUtility.ReplacePrefab(atlasObj, prefab, ReplacePrefabOptions.ConnectToPrefab);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        //销毁原来对象
        DestroyImmediate(atlasObj);
    }

    private void ConfigureForAtlas(string texturePath)
    {
        //1--获取指定路径下的纹理
        TextureImporter texImport = AssetImporter.GetAtPath(texturePath) as TextureImporter;
        texImport.textureType = TextureImporterType.Sprite;
        //2--修改此纹理的设置
        TextureImporterSettings texSettings = new TextureImporterSettings();
        texImport.ReadTextureSettings(texSettings);
        texSettings.mipmapEnabled = false;
        texSettings.readable = true;
        //texSettings.maxTextureSize = 2048;
        //texSettings.textureFormat = TextureImporterFormat.ARGB32;
        texSettings.filterMode = FilterMode.Point;
        texSettings.wrapMode = TextureWrapMode.Clamp;
        texSettings.npotScale = TextureImporterNPOTScale.None;
        texImport.SetTextureSettings(texSettings);

        TextureImporterPlatformSettings texPlatFormSettings = new TextureImporterPlatformSettings();
        texPlatFormSettings.maxTextureSize = 2048;
        texPlatFormSettings.format = TextureImporterFormat.ARGB32;
        //texPlatFormSettings.overridden = false;
        texPlatFormSettings.textureCompression = TextureImporterCompression.Uncompressed;
        //texPlatFormSettings.crunchedCompression = false;
        //texPlatFormSettings.allowsAlphaSplitting = true;
        texImport.SetPlatformTextureSettings(texPlatFormSettings);

        //3--重新把纹理导入到unity中
        AssetDatabase.ImportAsset(texturePath, ImportAssetOptions.ForceUpdate);
        AssetDatabase.Refresh();
    }
}
#endif
