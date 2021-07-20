using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public enum SceneToLoad
    {
        TutorialLevel,
        Level1
    }

    public void LoadScene(string load)
    {
        if (load == SceneToLoad.TutorialLevel.ToString())
            SceneManager.LoadScene(SceneNameConsts.TUTORIAL_NAME);
        if (load == SceneToLoad.Level1.ToString())
            SceneManager.LoadScene(SceneNameConsts.LEVEL_1_NAME);
    }
}
