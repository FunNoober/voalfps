using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager current;
    public int currentIndex;

    private void Awake()
    {
        if (current == null)
            current = this;
    }
}
