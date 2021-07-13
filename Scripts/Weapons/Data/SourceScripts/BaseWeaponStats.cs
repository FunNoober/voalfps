using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Stats", menuName = "Scriptable Objects/Weapons/Guns/New Weapon Stats")]
public class BaseWeaponStats : ScriptableObject
{
    public int maxReserve;
    public int magSize;

    public float fireRate;
    public float range;
    public int damage;

    public float reloadTime;

    public LayerMask shootMask;
    
    [Header("Animations")]
    public AnimationClip shootClip;
    public AnimationClip reloadClip;
}
