using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONModdingSystem : MonoBehaviour
{
    public T OpenJSON<T>(string pathName)
    {
        string path = Application.persistentDataPath + "/" + name;
        string json = System.IO.File.ReadAllText(path);
        T t = JsonUtility.FromJson<T>(json);
        return t;
    }
}
