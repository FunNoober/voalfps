using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathUI : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneNameConsts.LoadCurrentScene();
    }
}
