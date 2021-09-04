using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelLoadRequest : MonoBehaviour
{
    public UnityEvent onSet;

    public void SetLevelToLoad(int i)
    {
        LevelLoaderManager.levelToLoad = i;
        onSet?.Invoke();
    }
}
