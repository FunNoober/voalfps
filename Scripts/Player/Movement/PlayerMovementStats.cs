using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Movement Stats", menuName = "Scriptable Objects/Player/Player Movement Data")]
public class PlayerMovementStats : ScriptableObject
{
    public float moveSpeed = 5;
    public float runSpeed = 8;
    public float maxStamina = 10;
    public float mouseSensitivity = 15;
    public float gravity = -9.81f;

    [Space(height: 20)]

    public float groundDistance;
    public float jumpHeight;
    public float doubleJumpHeight;

    [Space(height: 20)]

    public LayerMask groundMask;

    [Space(height: 20)]

    [Header("Should Use")]
    public bool shouldUseStaminia = true;
    public bool hasRun = true;
    public bool hasGravity = true;
    public bool canCrouch = true;
    public bool shouldUseJump = true;
    public bool shouldUseDoubleJump = true;
    public bool hasAirStrafe = true;
    public bool hasFlashlight;
}
