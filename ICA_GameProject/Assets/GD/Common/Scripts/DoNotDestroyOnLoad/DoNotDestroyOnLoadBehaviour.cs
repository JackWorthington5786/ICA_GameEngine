using UnityEngine;

namespace GD
{
    public class DoNotDestroyOnLoadBehaviour : MonoBehaviour
    {
        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            // Ensure that this object is not destroyed when loading a new scene
            DontDestroyOnLoad(gameObject);
        }
    }
}