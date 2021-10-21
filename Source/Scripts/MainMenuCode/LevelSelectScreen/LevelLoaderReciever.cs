using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoaderReciever : MonoBehaviour
{
    public Text infoText;
    public Text levelText;

    public int missionToLoad;

    public LevelInfo[] levels;

    private void Start()
    {
        if(levels.Length >= 6)
        {
            if(LevelLoaderManager.levelToLoad == 0)
            {
                infoText.text = levels[0].info;
                levelText.text = levels[0].levelName;
                missionToLoad = levels[0].mission;
            }
            if (LevelLoaderManager.levelToLoad == 1)
            {
                infoText.text = levels[1].info;
                levelText.text = levels[1].levelName;
                missionToLoad = levels[1].mission;
            }
            if (LevelLoaderManager.levelToLoad == 2)
            {
                infoText.text = levels[2].info;
                levelText.text = levels[2].levelName;
                missionToLoad = levels[2].mission;
            }
        }
    }

    public void LoadMission()
    {
        SceneManager.LoadScene(missionToLoad);
    }
}

[System.Serializable]
public class LevelInfo
{
    public string info;
    public string levelName;
    public int mission;
}