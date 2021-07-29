using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LoadingPathConsts
{
    public static string Path(string name, string extension = ".json")
    {
        return Application.persistentDataPath + "/" + name + extension;
    }
}
