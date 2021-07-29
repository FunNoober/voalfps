using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaterYAxis_S : FNTweener
{
    private void Start()
    {
        LeanTween.rotateAroundLocal(gameObject, Vector3.up, amount, time).setLoopPingPong();
    }
}
