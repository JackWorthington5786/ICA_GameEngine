using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Vector3 moveDistance;
    public float slidingSpeed;
    public bool autoClose = true;
    public float autoCloseDelay;
    public GameObject doorObject; 
    
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private bool isOpen = false;
    
    //bool for if the door is locked
    public bool isLocked = false;
    
    public Light targetLight;
    public Color enterColor = Color.green;
    public Color exitColor = Color.red;

    public GameObject card;
    
    void Start()
    {
        if (doorObject == null)
        {
            Debug.LogError("Door object not assigned to the SlidingDoorController script!");
            return;
        }

        originalPosition = doorObject.transform.position;
        targetPosition = originalPosition + moveDistance;
    }

    void Update()
    {
        // Move the door towards the target position.
        if (isOpen)
        {
            ChangeLightColor(enterColor);
            SetCubeVisibility(true);
            doorObject.transform.position = Vector3.MoveTowards(doorObject.transform.position, targetPosition, Time.deltaTime * slidingSpeed);
        }
        else
        {
            ChangeLightColor(exitColor);
            SetCubeVisibility(false);
            doorObject.transform.position = Vector3.MoveTowards(doorObject.transform.position, originalPosition, Time.deltaTime * slidingSpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isLocked)
        {
            isOpen = true;
            CancelInvoke("CloseDoor"); // Cancel any scheduled automatic door closing.
        }
        else if (other.CompareTag("Player") && isLocked && other.GetComponent<PickupBehaviour>().hasKey)
        {
            
            isOpen = true;
            CancelInvoke("CloseDoor"); // Cancel any scheduled automatic door closing.
        }
        else if (other.CompareTag("Player") && isLocked && !other.GetComponent<PickupBehaviour>().hasKey)
        {
            Debug.Log("Door is locked");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (autoClose)
            {
                Invoke("CloseDoor", autoCloseDelay);
            }
            isOpen = false;
            
            //if the door is locked, remove the key from the player
            if (isLocked)
            {
                other.GetComponent<PickupBehaviour>().hasKey = false;
            }
        }
        
    }

    void CloseDoor()
    {
        isOpen = false;
    }
    
    void ChangeLightColor(Color newColor)
    {
        if (targetLight != null)
        {
            targetLight.color = newColor;
        }
    }
    void SetCubeVisibility(bool isVisible)
    {
        if (card != null)
        {
            card.SetActive(isVisible);
        }
    }
}

