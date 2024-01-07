using UnityEngine;

namespace GD.Selection
{
    public class GameObjectRayProvider : MonoBehaviour, IRayProvider
    {
        [SerializeField]
        [Tooltip("Normally set to the in-game player game object")]
        private GameObject rayOrigin;

        [SerializeField]
        private Color rayColor;

        [SerializeField]
        [Range(1, 100)]
        private float rayLength = 20;

        private Ray ray;

        public Ray CreateRay()
        {
            ray = new Ray(rayOrigin.transform.position, rayOrigin.transform.forward);
            return ray;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = rayColor;
            Gizmos.DrawLine(ray.origin, ray.origin + rayLength * ray.direction);
        }
    }
}