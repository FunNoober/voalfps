using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminAccess : MonoBehaviour
{
    public bool hasAdmin = false;
    public bool IsDisabled = false;
    public bool CanBeDestroyed = false;

    public string textToDisplay;
    public string playerTag;

    public int triggeredCounter;

    public Text adminText;

    public GameObject theText;
    public GameObject theSelf;

    void OnTriggerEnter()
    {
        StartCoroutine(displayText());
        CheckCounter();
    }

    IEnumerator displayText()
    {
        if(hasAdmin == false)
        {
        theText.SetActive(true);
        adminText.text = textToDisplay;
        triggeredCounter += 1;
        yield return new WaitForSeconds(3);
        theText.SetActive(false);
        }
    }

    public void CheckCounter()
    {
        if(triggeredCounter >= 4)
        {
            triggeredCounter = Mathf.Clamp(triggeredCounter, 0, 3);
        }
        if(triggeredCounter == 3)
        {
            CanBeDestroyed = true;
        }
        if(CanBeDestroyed == true)
        {
            theSelf.SetActive(false);
            theText.SetActive(false);
            IsDisabled = true;
        }
    }

}
