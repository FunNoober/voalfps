using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SurvivalManager : MonoBehaviour
{
    public int score = 100;
    
    public TextMeshProUGUI scoreCounter;

    void Update()
    {
        scoreCounter.text = "Score:" + score.ToString();
    }
}
