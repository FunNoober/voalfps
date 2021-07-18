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

    public float bobWhileRunning = 0.03f;
    public float runBobSpeed = 6f;
    public float baseBob = 0.01f;
    public float baseBobSpeed = 2f;

    public LayerMask shootMask;

    public enum WeaponType
    {
        OneBullet,
        Spread
    }

    public WeaponType type;

    public float spead;
    
    [Header("Animations")]
    public AnimationClip shootClip;
    public AnimationClip reloadClip;
}
