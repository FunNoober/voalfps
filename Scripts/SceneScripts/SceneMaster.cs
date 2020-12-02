using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{
    public Animator fadeOut;
    public GameObject Menu;
    
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void CallQuit(float waitLength)
    {
        StartCoroutine(ExitGame(waitLength));
    }
    
    IEnumerator ExitGame(float waitTime)
    {
        fadeOut.Play("ExitAnimation");
        Menu.SetActive(false);
        yield return new WaitForSeconds(waitTime);
        Application.Quit();
    }
}
