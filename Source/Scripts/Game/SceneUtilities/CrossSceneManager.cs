using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossSceneManager : MonoBehaviour
{
    public void LoadSceneString(string name)
    {
        SceneNameConsts.LoadLevel(name);
    }

    public void LoadSceneIndex(int index)
    {
        SceneNameConsts.LoadLevelI(index);
    }
}
