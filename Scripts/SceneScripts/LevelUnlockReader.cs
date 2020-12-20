using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlockReader : MonoBehaviour
{
    public GameObject level1Button;
    public GameObject level2Button;
    public GameObject level3Button;

    public bool hasLevel1;
    public bool hasLevel2;


    private void Update()
    {
        hasLevel1 = LevelUnlock.level1;
        hasLevel2 = LevelUnlock.level2;
    }
    void Start()
    {
        if(LevelUnlock.level1 == false)
        {
            level1Button.SetActive(false);
        }
        else
        {
            level1Button.SetActive(true);
        }
        
        
        
        if(LevelUnlock.level2 == false)
        {
            level2Button.SetActive(false);
        }
        else
        {
            level2Button.SetActive(true);
        }
    }
}
