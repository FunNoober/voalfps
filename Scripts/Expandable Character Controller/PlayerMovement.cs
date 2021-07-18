/*Fun Noober 2021 Expandable First Person Movement System*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))] //if the script is placed on an object that does not have a character controller then it will add one
public class PlayerMovement : MonoBehaviour
{
    public PlayerMovementStats stats;

    [Tooltip("The Player Controller")]
    public CharacterController playerController;
    [Tooltip("The Child Cam of this Object")]
    public Camera mainCam;
    [Tooltip("The Flashlight Object To Enable and Disable")]
    public Light flashLight;
    [Tooltip("The Remaining Staminia")]
    public float currentStamina = 10;
    [Tooltip("How Small The Player Should Get While Crouching")]
    public float crouchHeight;

    [Tooltip("The Object Where To Check for Ground")]
    public GameObject groundCheck;

    public GameObject devConsole;

    public StarndardActions actions;

    //privates
    private Vector3 velocity;
    private bool isGrounded;
    private bool canRun = true;

    private float xRotation;
    private float startPlayerHeight;
    private float mouseX;
    private float mouseY;

    private float xVector;
    private float zVector;
    private bool hasUsedDoubleJump = false;
    private bool flashLightEnabled = false;
    private bool consoleIsEnabled = false;
    private bool inputEnabled;

    public static bool isRunning;

    void Awake()
    {
        inputEnabled = true;

        actions = new StarndardActions();

        playerController = GetComponent<CharacterController>(); //auto assigning the character controller;
        if (stats.shouldUseStaminia == true)
            currentStamina = stats.maxStamina; //setting the current stamina on start;

        startPlayerHeight = playerController.height; //setting the player to the max height;
    }

    #region

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    #endregion

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //disabling the cursor
    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.transform.position, stats.groundDistance, stats.groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -3f;
            hasUsedDoubleJump = false;
        }

        if (inputEnabled == true)
        {
            if (isGrounded && stats.hasAirStrafe == false)
            {
                xVector = actions.StarndardInput.HorizontalInput.ReadValue<Vector2>().x; //getting a or d input
                zVector = actions.StarndardInput.HorizontalInput.ReadValue<Vector2>().y; //getting w or s input
                if (xVector != 0)
                    Debug.Log(xVector);
            }

            if (stats.hasAirStrafe == true)
            {
                xVector = actions.StarndardInput.HorizontalInput.ReadValue<Vector2>().x; //getting a or d input
                zVector = actions.StarndardInput.HorizontalInput.ReadValue<Vector2>().y; //getting w or s input
            }
        }


        Vector3 move = transform.right * xVector + transform.forward * zVector;
        playerController.Move(move * stats.moveSpeed * Time.deltaTime);

        if (actions.StarndardInput.Run.ReadValue<float>() == 1 && canRun == true && stats.hasRun == true) //Checking if the player can run
        {
            playerController.Move(move * stats.runSpeed * Time.deltaTime);
            isRunning = true;
            if (stats.shouldUseStaminia == true)
                currentStamina -= Time.deltaTime;
        }
        else { isRunning = false; }

        if (actions.StarndardInput.Jump.ReadValue<float>() == 1 && stats.shouldUseJump) //Cecking if the player can jump
            Jump();

        if (actions.StarndardInput.Jump.ReadValue<float>() == 1 && stats.shouldUseDoubleJump && hasUsedDoubleJump == false) //Checking if the player can double jump
            DoubleJump();

        if (actions.StarndardInput.Crouch.ReadValue<float>() == 1 && stats.canCrouch) //Checking if the player can crouch
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

        currentStamina = Mathf.Clamp(currentStamina, 0, stats.maxStamina);

        if (stats.hasGravity == true) //checking for gravity
            velocity.y += stats.gravity * Time.deltaTime;

        playerController.Move(velocity * Time.deltaTime); //moving the player


        if(inputEnabled == true)
        {
            mouseX = actions.StarndardInput.VerticalInput.ReadValue<Vector2>().x * stats.mouseSensitivity * Time.deltaTime;
            mouseY = actions.StarndardInput.VerticalInput.ReadValue<Vector2>().y * stats.mouseSensitivity * Time.deltaTime;
        }

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 65f); //clamping the vertical rotation of the camera

        mainCam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

        if (actions.StarndardInput.FlashLight.triggered && stats.hasFlashlight)
        {
            if (flashLightEnabled == false)
            {
                flashLight.gameObject.SetActive(true);
                flashLightEnabled = true;
                return;
            }

            if (flashLightEnabled == true)
            {
                flashLight.gameObject.SetActive(false);
                flashLightEnabled = false;
                return;
            }
        }

        if (actions.StarndardInput.ConsoleKey.triggered)
        {
            if (consoleIsEnabled == false)
            {
                devConsole.SetActive(true);
                consoleIsEnabled = true;
                inputEnabled = false;
                Cursor.lockState = CursorLockMode.None;
                return;
            }
            else
            {
                devConsole.SetActive(false);
                consoleIsEnabled = false;
                inputEnabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                return;
            }
        }
    }


    void Jump()
    {
        if (isGrounded == true)
        {
            velocity.y = stats.jumpHeight; //Applying The Force
            velocity.y -= stats.gravity * Time.deltaTime; //Applying The Gravity
            playerController.Move(velocity * Time.deltaTime); //Moving The Player
        }
    }

    void DoubleJump()
    {
        if (isGrounded == false && hasUsedDoubleJump == false)
        {
            velocity.y = stats.doubleJumpHeight; //Applying The Force
            velocity.y -= stats.gravity * Time.deltaTime; //Applying The Gravity
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
