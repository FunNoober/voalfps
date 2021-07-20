using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionLevelManager : MonoBehaviour
{
    public string objective;
    public string objectiveUnsplit;
    public Text objectiveText;

    [Range(0.1f, 0.75f)]
    public float timePerChar = 0.25f;

    private void Awake()
    {
        objectiveText.text = "";

        StartCoroutine(DisplayObjective());
    }

    public IEnumerator DisplayObjective()
    {
        string[] objectiveChars = objective.Split(',');
        while(objectiveText.text != objectiveUnsplit)
        {
            for (int i = 0; i < objectiveChars.Length; i++)
            {
                yield return new WaitForSeconds(timePerChar);
                objectiveText.text += objectiveChars[i];
            }
        }
    }
}
