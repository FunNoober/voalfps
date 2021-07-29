using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverYAxis_S : FNTweener
{
    void Start()
    {
        float newAmount = transform.position.y + amount;
        LeanTween.moveLocalY(gameObject, newAmount, time).setLoopPingPong().setEaseInOutBounce();
    }
}
