using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script Will Be In Charge Of Rotating The Player

public class PlayerMovementRotation : MonoBehaviour
{
    //Floats
    public float mouseSensitivity = 5f;
    public float xRotation = 0f;

    //GameObjects

    //Transforms
    public Transform playerObject;

    //Bools
   
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85, 65f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerObject.Rotate(Vector3.up * mouseX);
    }
}


