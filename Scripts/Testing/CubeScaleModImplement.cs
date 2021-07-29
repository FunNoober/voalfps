using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CubeScaleModImplement : MonoBehaviour, IModdable
{
    public Vector3 size;

    string path;

    private void Awake()
    {
        path = LoadingPathConsts.Path("scalableCubeTest");
    }

    public void CreateIfNotLoaded()
    {
        CubeScaleData modImplement = new CubeScaleData
        {
            Size = new Vector3(1, 1, 1)
        };

        string json = JsonUtility.ToJson(modImplement);
        File.WriteAllText(path, json);
    }

    public void LoadData()
    {
        string json = File.ReadAllText(path);
        CubeScaleData scaleMod = JsonUtility.FromJson<CubeScaleData>(json);
        size = scaleMod.Size;
        transform.localScale = size;
    }

    public void Mod()
    {
        if (File.Exists(path))
        {
            LoadData();
        }
        else
        {
            CreateIfNotLoaded();
        }
    }

    public class CubeScaleData
    {
        public Vector3 Size;
    }
}
