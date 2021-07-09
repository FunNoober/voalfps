/*Fun Noober 2021 Expandable First Person Movement System*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] //if the script is placed on an object that does not have a character controller then it will add one
public class PlayerMovement : MonoBehaviour
{
    [Tooltip("The Player Controller")]
    public CharacterController playerController;
    [Tooltip("The Child Cam of this Object")]
    public Camera mainCam;
    [Tooltip("The Flashlight Object To Enable and Disable")]
    public Light flashLight;
    [Tooltip("Move Speed With No Run")]
    public float moveSpeed = 5;
    [Tooltip("Movement Speed While Running")]
    public float runSpeed = 8;
    [Tooltip("The Max Amount of Staminia")]
    public float maxStamina = 10;
    [Tooltip("The Remaining Staminia")]
    public float currentStamina = 10;
    [Tooltip("The Sensitivity of The Mouse")]
    public float mouseSensitivity = 500;
    [Tooltip("The Gravity Force")]
    public float gravity = -9.81f;
    [Tooltip("How Small The Player Should Get While Crouching")]
    public float crouchHeight;

    [Tooltip("The Size of The Sphere when Checking for Ground")]
    public float groundDistance = 0.1f;
    [Tooltip("The Force of The Jump")]
    public float jumpHeight = 3;
    [Tooltip("How High The Player Should Jump When Double Jumping")]
    public float doubleJumpHeight = 6;
    [Tooltip("The Object Where To Check for Ground")]
    public GameObject groundCheck;
    [Tooltip("The Objects That Are Ground")]
    public LayerMask groundMask;

    [Header("Should Use")]
    public bool shouldUseStaminia = true;
    public bool hasRun = true;
    public bool hasGravity = true;
    public bool canCrouch = true;
    public bool shouldUseJump = true;
    public bool shouldUseDoubleJump = true;
    public bool hasAirStrafe = true;
    public bool hasFlashlight;
    [Header("Key Binds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode crouchKey = KeyCode.LeftControl;
    public KeyCode runKey = KeyCode.LeftShift;
    public KeyCode flashLightKey = KeyCode.F;

    //privates
    private Vector3 velocity;
    private bool isGrounded;
    private bool canRun = true;
    private float xRotation;
    private float startPlayerHeight;

    private float xVector;
    private float zVector;
    private bool hasUsedDoubleJump = false;
    private bool flashLightEnabled = false;

    void Awake()
    {
        playerController = GetComponent<CharacterController>(); //auto assigning the character controller;
        if (shouldUseStaminia == true)
            currentStamina = maxStamina; //setting the current stamina on start;

        startPlayerHeight = playerController.height; //setting the player to the max height;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //disabling the cursor
    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -3f;
            hasUsedDoubleJump = false;
        }
        
        if(isGrounded && hasAirStrafe == false)
        {
            xVector = Input.GetAxisRaw("Horizontal"); //getting a or d input
            zVector = Input.GetAxisRaw("Vertical"); //getting w or s input
        }

        if(hasAirStrafe == true)
        {
            xVector = Input.GetAxisRaw("Horizontal"); //getting a or d input
            zVector = Input.GetAxisRaw("Vertical"); //getting w or s input
        }
        
        Vector3 move = transform.right * xVector + transform.forward * zVector;
        playerController.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetKey(runKey) && canRun == true && hasRun == true) //Checking if the player can run
        {
            playerController.Move(move * runSpeed * Time.deltaTime);
            if (shouldUseStaminia == true)
                currentStamina -= Time.deltaTime;
        }

        if (Input.GetKeyDown(jumpKey) && shouldUseJump) //Cecking if the player can jump
            Jump();

        if(Input.GetKeyDown(jumpKey) && shouldUseDoubleJump && hasUsedDoubleJump == false) //Checking if the player can double jump
            DoubleJump();

        if (Input.GetKey(crouchKey) && canCrouch) //Checking if the player can crouch
        {
            playerController.height = crouchHeight;
        }
        else
            playerController.height = startPlayerHeight;

        if (currentStamina <= 0) //If the stamina is below or is zero then it will disable the run
        {
            canRun = false;
            StartCoroutine(GiveStaminia());
        }

        if (currentStamina > 0) //if the stamina is not 0 then the player can run
        {
            canRun = true;
        }

        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

        if (hasGravity == true) //checking for gravity
            velocity.y += gravity * Time.deltaTime;

        playerController.Move(velocity * Time.deltaTime); //moving the player

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 65f); //clamping the vertical rotation of the camera

        mainCam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

        if(Input.GetKeyDown(flashLightKey) && hasFlashlight)
        {
            if(flashLightEnabled == false)
            {
                flashLight.gameObject.SetActive(true);
                flashLightEnabled = true;
                return;
            }

            if(flashLightEnabled == true)
            {
                flashLight.gameObject.SetActive(false);
                flashLightEnabled = false;
                return;
            }
        }
    }


    void Jump()
    {
        if (isGrounded == true)
        {
            velocity.y = jumpHeight; //Applying The Force
            velocity.y -= gravity * Time.deltaTime; //Applying The Gravity
            playerController.Move(velocity * Time.deltaTime); //Moving The Player
        }
    }

    void DoubleJump()
    {
        if(isGrounded == false && hasUsedDoubleJump == false)
        {
            velocity.y = doubleJumpHeight; //Applying The Force
            velocity.y -= gravity * Time.deltaTime; //Applying The Gravity
            playerController.Move(velocity * Time.deltaTime); //Moving The Player
            hasUsedDoubleJump = true;
        }
    }

    IEnumerator GiveStaminia()
    {
        yield return new WaitForSeconds(3); //waiting before giving stamina
        currentStamina += Time.deltaTime; //giving stamina back over time
    }
}
