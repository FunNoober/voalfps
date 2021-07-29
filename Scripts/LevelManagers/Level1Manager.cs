using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Manager : MonoBehaviour
{
    public void MissionCountdown()
    {
        StartCoroutine(StartMissionCountdown());
        Debug.Log("Started Counting");
    }

    public IEnumerator StartMissionCountdown()
    {
        yield return new WaitForSeconds(60);
        SceneManager.LoadScene(SceneNameConsts.LEVEL_2_NAME);
    }
}
