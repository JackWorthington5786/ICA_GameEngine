using GD;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    //event to raise when we pick up an item
    [SerializeField]
    private ItemDataGameEvent OnPickup;

    //tag of the object we want to pick up
    [SerializeField]
    private string targetTag = "Keycard";
    
    //have key bool
    [SerializeField] public bool hasKey = false;

    //when we enter the trigger of the pickup object (collide with it) 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(targetTag))
        {
            //try to get the data from the pickup
            var itemDataBehaviour = other.gameObject.GetComponent<ItemDataBehaviour>();

            //raise the event (tell the EventManager that this thing happened)
            OnPickup?.Raise(itemDataBehaviour.ItemData);

            //play where item was
            AudioSource.PlayClipAtPoint(itemDataBehaviour.ItemData.PickupClip,
              other.gameObject.transform.position);

            Destroy(other.gameObject, itemDataBehaviour.ItemData.PickupClip.length);
            
            //make key true
            hasKey = true;
        }
    }
}