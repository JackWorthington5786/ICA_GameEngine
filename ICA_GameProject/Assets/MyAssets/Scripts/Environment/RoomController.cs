using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public float moveDistance = 3f;
    public float moveSpeed = 3f;
    public GameObject movingPlatform;
    private Vector3 originalPosition;
    private bool playerInside = false;
    
    void Start()
    {
        originalPosition = movingPlatform.transform.position;
    }

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

    void MovePlatformUp()
    {
        Vector3 targetPosition = originalPosition + Vector3.up * moveDistance;
        movingPlatform.transform.position = Vector3.MoveTowards(movingPlatform.transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }

    void ReturnToOriginalPosition()
    {
        movingPlatform.transform.position = Vector3.MoveTowards(movingPlatform.transform.position, originalPosition, Time.deltaTime * moveSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
    
}