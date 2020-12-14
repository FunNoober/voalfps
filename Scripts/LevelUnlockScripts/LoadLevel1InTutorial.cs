using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel1InTutorial : MonoBehaviour
{
    public SceneMaster mainSceneManager;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            mainSceneManager.LoadScene(4);
            LevelUnlock.level1 = true;
        }
    }
}
