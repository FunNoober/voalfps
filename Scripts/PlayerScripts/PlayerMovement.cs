using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script Will Be In Charge Of Moving The Player

public class PlayerMovement : MonoBehaviour
{
    //Floats
    public float moveSpeed = 8f;
    public float runSpeed = 11f;
    public float gravity = -9.81f;
    public float groundDistance = 0.5f;
    public float stamina = 10f;
    public float maxStamina = 10f;

    //Transforms
    Vector3 velocity;
    public Transform groundCheckerMachine;

    //GameObjects
    public CharacterController playerController;
    public LayerMask groundMask;

    //Bools
    bool isGrounded;

    public bool isRunning;
    public bool canRun = true;


    void Start()
    {
        
    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheckerMachine.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -3f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        playerController.Move(move * moveSpeed * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftShift) && canRun == true)
        {
            playerController.Move(move * runSpeed * Time.deltaTime);
            stamina -= Time.deltaTime;
        }

        if(stamina <= 0)
        {
            canRun = false;
            StartCoroutine(giveStamina());
        }

        if(stamina >= maxStamina)
        {
            canRun = true;
        }

        stamina = Mathf.Clamp(stamina, 0, maxStamina -1);

        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }

    IEnumerator giveStamina()
    {
        yield return new WaitForSeconds(4);
        stamina += 1f;
    }
}
