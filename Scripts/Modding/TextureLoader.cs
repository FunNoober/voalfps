using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextureLoader : MonoBehaviour
{
    public TextureLoaderData texLoadData;

    private void Awake()
    {
        foreach (TexturesToLoad texToLoad in texLoadData.texsToLoad)
        {
            if (File.Exists(LoadingPathConsts.Path(texToLoad.texName, ".png")))
            {
                Texture2D tex = new Texture2D(2, 2);
                tex.LoadImage(File.ReadAllBytes(LoadingPathConsts.Path(texToLoad.texName, ".png")));
                texToLoad.matToChange.EnableKeyword("_NORMALMAP");
                texToLoad.matToChange.SetTexture("_BumpMap", tex);
            }
        }
    }

}

