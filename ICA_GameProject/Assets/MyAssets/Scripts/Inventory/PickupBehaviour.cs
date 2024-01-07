using GD;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    [SerializeField]
    private ItemDataGameEvent OnPickup;

    [SerializeField]
    private string targetTag = "Keycard";
    
    //have key bool
    [SerializeField] public bool hasKey = false;

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