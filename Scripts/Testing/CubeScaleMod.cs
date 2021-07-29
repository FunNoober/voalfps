using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScaleMod : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<IModdable>().Mod();
    }
}
