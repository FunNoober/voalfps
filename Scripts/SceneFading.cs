using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFading : MonoBehaviour
{
    public CanvasGroup fade;

    public float fadeTime;
    public bool hasFadedOut;
    public bool hasStartedFade = false;

    private void Awake()
    {
        fade.alpha = 1;
    }

    private void Update()
    {
        if (fade.alpha > 0 && !hasFadedOut)
            fade.alpha -= Time.deltaTime;
        if (fade.alpha == 0)
            hasFadedOut = true;
        
        if(hasStartedFade == true)
        {
            fade.alpha += Time.deltaTime;
            if(fade.alpha == 1)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void FadeIn()
    {
        hasStartedFade = true;
        //Debug.Log("Fading");
        //fade.alpha += Time.deltaTime;
        //Debug.Log(fade.alpha.ToString());
        //if(fade.alpha == 1)
        //{
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}
    }
}
