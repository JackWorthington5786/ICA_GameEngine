using UnityEngine;

namespace GD
{
    /// <summary>
    /// Add to a object to ensure that the attached game object always "looks at" the camera. The object can be oriented as a spherical, vertical or horizontal billboard.
    /// Spherical - always face camera. Vertical - face camera but rotate only around world Y-axis. Horizontal - face camera but only rotate around world X-axis
    /// </summary>
    /// <see cref="http://wiki.unity3d.com/index.php/LookAtCameraYonly?_ga=2.74143954.1733079655.1618664692-1586311830.1610367054"/>
    public class LookAtTarget : MonoBehaviour
    {
        // Enum to specify different billboard orientation types
        public enum BillboardOrientationType : sbyte
        {
            Spherical, Vertical, Horizontal
        }

        [SerializeField]
        [Tooltip("Spherical - always face camera. Vertical - face camera but rotate only around world Y-axis. Horizontal - face camera but only rotate around world X-axis")]
        private BillboardOrientationType billboardOrientationType = BillboardOrientationType.Spherical;

        [SerializeField]
        private Camera targetCamera;

        private void Awake()
        {
            // If targetCamera is not set, default to the main camera in the scene
            if (targetCamera == null)
                targetCamera = Camera.main;
        }

        private void Update()
        {
            // Make the object face towards the camera
            transform.LookAt(transform.position + targetCamera.transform.rotation * Vector3.forward, targetCamera.transform.rotation * Vector3.up);

            // Adjust rotation based on billboard orientation type
            if (billboardOrientationType == BillboardOrientationType.Vertical)
            {
                // Limit rotation to only around the Y-axis
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
            }
            else if (billboardOrientationType == BillboardOrientationType.Horizontal)
            {
                // Limit rotation to only around the X-axis
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            }
        }
    }
}