using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script Will Be In Charge Of Moving The Player

public class PlayerMovement : MonoBehaviour
{
    //Floats
    public float moveSpeed = 8f;
    public float runSpeed = 11f;

    #region Defaults
    public float defaultmoveSpeed;
    public float defualtRunSpeed;
    #endregion Defaults

    public float gravity = -9.81f;
    public float groundDistance = 0.5f;
    public float stamina = 10f;
    public float maxStamina = 10f;

    public float jumpHeight = 10;

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

    #region Happening On Start
    private void Awake()
    {
        defaultmoveSpeed = moveSpeed;
        defualtRunSpeed = runSpeed;
        jumpHeight = 3;
    }
    #endregion Happening On Start


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

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            velocity.y = jumpHeight;
            velocity.y -= gravity * Time.deltaTime;
            playerController.Move(velocity * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.LeftShift) && canRun == true)
        {
            playerController.Move(move * runSpeed * Time.deltaTime);
            stamina -= Time.deltaTime;
        }


        #region Running
        if (stamina <= 0)
        {
            canRun = false;
            StartCoroutine(GiveStamina());
        }

        if(stamina >= maxStamina)
        {
            canRun = true;
        }
        #endregion Running

        stamina = Mathf.Clamp(stamina, 0, maxStamina -1);

        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);




    }
    private void LateUpdate()
    {
        #region Crouching
        if (Input.GetKey(KeyCode.LeftControl))
        {
            playerController.height = .5f;
        }
        else
        {
            playerController.height = 2f;
            moveSpeed = defaultmoveSpeed;
            runSpeed = defualtRunSpeed;
        }
        #endregion Crouching
    }

    IEnumerator GiveStamina()
    {
        yield return new WaitForSeconds(4);
        stamina += 1f;
    }
}
