using System;
using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public Jump_s sJump;
    public Flashlight_s sFlashlight;
    public DevConsole_s sConsole;
    public PauseResume_s sPauseResume;
    public Crouch_s sCrouch;

    public PlayerMovementStats stats;
    public CharacterController playerController;
    public Camera mainCam;
    public float maxJetpack = 10;
    public GameObject groundCheck;
    public StarndardActions actions;
    public enum ShiftType
    {
        sprint,
        jetpack
    }
    public ShiftType shiftType;
    [SerializeField]
    private float jetpackRemaining;
    private Vector3 velocity;
    private bool isGrounded;
    [SerializeField]
    private bool canJetpack => jetpackRemaining >= 0;
    private float xRotation;
    private float mouseX;
    private float mouseY;
    private float xVector;
    private float zVector;
    private bool hasUsedDoubleJump = false;
    private bool inputEnabled;
    private bool isUsingJetpack;
    public static bool isRunning;

    void Awake()
    {
        #region json
        string path = LoadingPathConsts.Path(stats.objectName);
        if (File.Exists(LoadingPathConsts.Path(stats.objectName)))
        {
            string json = File.ReadAllText(path);
            Stats jStats = JsonUtility.FromJson<Stats>(json);

            if (stats.canMod && stats.canMod2Step)
            {
                stats.moveSpeed = jStats.MoveSpeed;
                stats.runSpeed = jStats.RunSpeed;
                stats.maxStamina = jStats.MaxStamina;
                stats.mouseSensitivity = jStats.MouseSensitivity;
                stats.gravity = jStats.Gravity;

                stats.jumpHeight = jStats.JumpHeight;
                stats.doubleJumpHeight = jStats.DoubleJumpHeight;
                stats.shouldUseDoubleJump = jStats.ShouldUseDoubleJump;
            }
        }
        else
        {
            Stats newJStats = new Stats
            {
                MoveSpeed = stats.moveSpeed,
                RunSpeed = stats.runSpeed,
                MaxStamina = stats.maxStamina,
                MouseSensitivity = stats.mouseSensitivity,
                Gravity = stats.gravity,
                JumpHeight = stats.jumpHeight,
                DoubleJumpHeight = stats.doubleJumpHeight,
                ShouldUseDoubleJump = stats.shouldUseDoubleJump
            };

            string json = JsonUtility.ToJson(newJStats);
            File.WriteAllText(LoadingPathConsts.Path(stats.objectName), json);
        }
        #endregion

        #region extra setup
        inputEnabled = true;

        actions = new StarndardActions();

        playerController = GetComponent<CharacterController>();
        #endregion
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
        Cursor.lockState = CursorLockMode.Locked;
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
                xVector = actions.StarndardInput.HorizontalInput.ReadValue<Vector2>().x;
                zVector = actions.StarndardInput.HorizontalInput.ReadValue<Vector2>().y;
                if (xVector != 0)
                    Debug.Log(xVector);
            }

            if (stats.hasAirStrafe == true)
            {
                xVector = actions.StarndardInput.HorizontalInput.ReadValue<Vector2>().x;
                zVector = actions.StarndardInput.HorizontalInput.ReadValue<Vector2>().y;
            }
        }


        Vector3 move = transform.right * xVector + transform.forward * zVector;
        playerController.Move(move * stats.moveSpeed * Time.deltaTime);

        if (actions.StarndardInput.Run.ReadValue<float>() == 1)
        {
            switch (shiftType)
            {
                case ShiftType.sprint:
                    if (stats.hasRun == true)
                    {
                        playerController.Move(move * stats.runSpeed * Time.deltaTime);
                        isRunning = true;
                    }
                    break;
                case ShiftType.jetpack:
                    if (canJetpack == true)
                    {
                        velocity.y = stats.jetpackForce;
                        velocity.y -= stats.gravity * Time.deltaTime;
                        playerController.Move(velocity * Time.deltaTime);
                        jetpackRemaining -= Time.deltaTime;
                        isUsingJetpack = true;
                    }
                    break;
            }
        }
        else { isRunning = false; isUsingJetpack = false; }

        if (jetpackRemaining <= maxJetpack && isUsingJetpack == false)
        {
            jetpackRemaining += Time.deltaTime;
        }

        velocity.y += sJump.h_Jump(actions, stats, isGrounded);

        if (actions.StarndardInput.Jump.ReadValue<float>() == 1 && stats.shouldUseDoubleJump && hasUsedDoubleJump == false)
            DoubleJump();

        if (stats.hasGravity == true)
            velocity.y += stats.gravity * Time.deltaTime;

        playerController.Move(velocity * Time.deltaTime);


        if (inputEnabled == true)
        {
            mouseX = actions.StarndardInput.VerticalInput.ReadValue<Vector2>().x * stats.mouseSensitivity * Time.deltaTime;
            mouseY = actions.StarndardInput.VerticalInput.ReadValue<Vector2>().y * stats.mouseSensitivity * Time.deltaTime;
        }

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 65f);

        mainCam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

        sFlashlight.h_Flashlight(actions, stats);

        sConsole.h_Console(actions);

        sPauseResume.h_PauseResume(actions);

        sCrouch.h_Crouch(actions, stats, playerController);
    }

    void DoubleJump()
    {
        if (isGrounded == false && hasUsedDoubleJump == false)
        {
            velocity.y = stats.doubleJumpHeight;
            velocity.y -= stats.gravity * Time.deltaTime;
            playerController.Move(velocity * Time.deltaTime);
            hasUsedDoubleJump = true;
        }
    }

    public class Stats
    {
        public float MoveSpeed;
        public float RunSpeed;
        public float MaxStamina;
        public float MouseSensitivity;
        public float Gravity;

        public float JumpHeight;
        public float DoubleJumpHeight;

        public bool ShouldUseDoubleJump;
    }
}
