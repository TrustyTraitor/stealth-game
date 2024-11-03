using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public Camera Camera;

    public float mouseSensX = 1000f;
    public float mouseSensY = 1000f;

    float xRotation = 0f;
    float yRotation = 0f;

    public float upperClamp = -90f;
    public float lowerClamp = 90f;

    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.IsInteractingWithUI == false)
        {
            //Get mouse input
            float mouseX = Input.GetAxis("Mouse X") * mouseSensX * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensY * Time.deltaTime;

            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, upperClamp, lowerClamp);

            yRotation += mouseX;

            transform.localRotation = Quaternion.Euler(0, yRotation, 0f);
            Camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0f);
        }
    }
}
