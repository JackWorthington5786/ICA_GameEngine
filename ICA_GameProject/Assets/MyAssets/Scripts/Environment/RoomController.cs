using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    //Room variables
    public float moveDistance = 3f;
    public float moveSpeed = 3f;
    public GameObject movingPlatform;
    private Vector3 originalPosition;
    private bool playerInside = false;
    
    //on start get the original position of the platform
    void Start()
    {
        originalPosition = movingPlatform.transform.position;
    }

    //on update check if the player is inside the room
    void Update()
    {
        if (playerInside)
        {
            MovePlatformUp();
        }
        else
        {
            ReturnToOriginalPosition();
        }
    }

    //move the platform up
    void MovePlatformUp()
    {
        Vector3 targetPosition = originalPosition + Vector3.up * moveDistance;
        movingPlatform.transform.position = Vector3.MoveTowards(movingPlatform.transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }

    //return the platform to its original position
    void ReturnToOriginalPosition()
    {
        movingPlatform.transform.position = Vector3.MoveTowards(movingPlatform.transform.position, originalPosition, Time.deltaTime * moveSpeed);
    }

    //check if the player is inside the room
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    //check if the player is outside the room
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
    
}