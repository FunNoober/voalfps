using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "Scriptable Objects/AI/Enemy/New Enemy Data")]
public class BaseEnemyData : ScriptableObject
{
    public float detectionRadius;
    public float attackRadius;
    public float fireRate;
    public LayerMask detectionMask;
    public LayerMask playerMask;
    public GameObject projectile;

    public bool useAnimations;

    public string walkAnimationBool;
    public string shootAnimation;
}
