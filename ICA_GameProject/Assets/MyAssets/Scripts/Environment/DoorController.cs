using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    //door variables
    public Vector3 moveDistance;
    public float slidingSpeed;
    public bool autoClose = true;
    public float autoCloseDelay;
    public GameObject doorObject; 
    
    //variables for the door's position
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private bool isOpen = false;
    
    //bool for if the door is locked
    public bool isLocked = false;
    
    //variables for the light and card
    public Light targetLight;
    public Color enterColor = Color.green;
    public Color exitColor = Color.red;

    public GameObject card;
    
    //on start, set the original position and the target position
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

    //on update, move the door towards the target position
    void Update()
    {
        // Move the door towards the target position if it is open, otherwise move it towards the original position.
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

    //on trigger enter, if the player is not locked, open the door
    void OnTriggerEnter(Collider other)
    {
        // Open the door if the player enters the trigger area.
        if (other.CompareTag("Player") && !isLocked)
        {
            isOpen = true;
            CancelInvoke("CloseDoor"); // Cancel any scheduled automatic door closing.
        }
        //if the door is locked, check if they have the key
        else if (other.CompareTag("Player") && isLocked && other.GetComponent<PickupBehaviour>().hasKey)
        {
            
            isOpen = true;
            CancelInvoke("CloseDoor"); // Cancel any scheduled automatic door closing.
        }
        //if the door is locked and does not have the key, tell them the door is locked
        else if (other.CompareTag("Player") && isLocked && !other.GetComponent<PickupBehaviour>().hasKey)
        {
            Debug.Log("Door is locked");
        }
    }

    //on trigger exit, close the door
    void OnTriggerExit(Collider other)
    {
        // Close the door if the player exits the trigger area.
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

    //close the door
    void CloseDoor()
    {
        isOpen = false;
    }
    
    //change the light color
    void ChangeLightColor(Color newColor)
    {
        if (targetLight != null)
        {
            targetLight.color = newColor;
        }
    }
    
    //set the cube visibility
    void SetCubeVisibility(bool isVisible)
    {
        if (card != null)
        {
            card.SetActive(isVisible);
        }
    }
}

