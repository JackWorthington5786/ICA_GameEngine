using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; 
    public float distance ; 
    public float height ; 
    public float rotationSpeed ; 

    private float currentRotation = 0f;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target not assigned to the CameraController script!");
        }
    }

    void Update()
    {
        // Handle rotation based on left and right arrow keys.
        HandleRotationInput();

        // Calculate the position of the camera.
        CalculateCameraPosition();
    }

    void HandleRotationInput()
    {
        // Rotate camera left.
        if (Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.A))
        {
            currentRotation += 90f;
        }

        // Rotate camera right.
        if (Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.D))
        {
            currentRotation -= 90f;
        }
    }

    void CalculateCameraPosition()
    {
        if (target != null)
        {
            // Calculate the rotation based on user input.
            Quaternion rotation = Quaternion.Euler(0f, currentRotation, 0f);

            // Calculate the desired position.
            Vector3 desiredPosition = target.position - rotation * Vector3.forward * distance;
            desiredPosition.y = target.position.y + height;

            // Smoothly move the camera towards the desired position.
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);

            // Point the camera at the target.
            transform.LookAt(target.position);
        }
    }
}
