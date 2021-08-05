using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_s : MonoBehaviour
{
    public float h_Jump(StarndardActions actions, PlayerMovementStats stats, bool isGrounded)
    {
        if (actions.StarndardInput.Jump.ReadValue<float>() == 1 && stats.shouldUseJump)
        {
            if (isGrounded == true)
            {
                Vector3 velocity = new Vector3(0, stats.jumpHeight, 0);
                velocity.y -= stats.gravity * Time.deltaTime;
                return velocity.y;
            }
            return 0;
        }
        return 0;
    }
}
