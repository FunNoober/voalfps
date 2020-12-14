using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel2InLevel1 : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(LoadLevel2());
    }

    
    IEnumerator LoadLevel2()
    {
        yield return new WaitForSeconds(120);
        SceneManager.LoadScene("Level2");
        LevelUnlock.level2 = true;
    }
}
