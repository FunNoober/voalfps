using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheats : MonoBehaviour
{
    public GameObject canvas;
    public GameObject weapons;
    public GameObject tooltipRenderer;

    public InputField cheatType;

    public void RecieveCheat()
    {
        if(cheatType.text == "hide ui 1")
            canvas.SetActive(false);

        if(cheatType.text == "hide ui 0")
            canvas.SetActive(true);

        if(cheatType.text == "hide weapons 1")
            weapons.SetActive(false);

        if(cheatType.text == "hide weapons 0")
            weapons.SetActive(true);

        if(cheatType.text == "hide other camera 1")
            tooltipRenderer.SetActive(false);

        if(cheatType.text == "hide other camera 0")
            tooltipRenderer.SetActive(true);
    }
}
