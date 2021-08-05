using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch_s : MonoBehaviour
{
    public float crouchHeight;
    public float startPlayerHeight;

    public void h_Crouch(StarndardActions actions, PlayerMovementStats stats, CharacterController playerController)
    {
        if (actions.StarndardInput.Crouch.ReadValue<float>() == 1 && stats.canCrouch)
        {
            playerController.height = crouchHeight;
        }
        else
            playerController.height = startPlayerHeight;
    }
}
