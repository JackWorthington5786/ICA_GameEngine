using System;
using UnityEngine;

namespace GD.Selection
{
    /// <summary>
    /// Sets a target ring (based on a user-defined prefab) on selection of an appropriate game object
    /// SO versions of the ISelectResponse classes that previously were implemented as MonoBehaviours
    /// This allows us to drag and drop multiple selection responses into a List<ISelectResponse> in the AdvancedSelectionManager
    /// </summary>
    [CreateAssetMenu(fileName = "SO_TargetSelectionResponse", menuName = "DkIT/Scriptable Objects/Other/Responses/Target")]
    [Serializable]
    public class SO_TargetSelectionResponse : ScriptableObject, ISelectionResponse
    {
        [SerializeField]
        [Tooltip("Set prefab object used for target highlighting")]
        private GameObject targetSelectionPrefab;

        [SerializeField]
        private LayerMask targetGroundLayerMask;

        [SerializeField]
        [Tooltip("Vertical offset on target highlight above ground layer")]
        private float targetOffset;

        private GameObject currentTargetInstance;
        private float scaleFactor = 5;
        private int rayCastDepth = 10;

        public void OnDeselect(Transform selection)
        {
            if (currentTargetInstance != null)
                currentTargetInstance.SetActive(false);
        }

        public void OnSelect(Transform selection)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(selection.position, -selection.up, out hitInfo, rayCastDepth, targetGroundLayerMask))
            {
                if (targetSelectionPrefab != null && currentTargetInstance == null)
                {
                    currentTargetInstance = Instantiate(targetSelectionPrefab, Vector3.zero, Quaternion.Euler(0, 0, 0));
                }

                currentTargetInstance.SetActive(true);
                currentTargetInstance.transform.position = selection.position - new Vector3(0, hitInfo.distance - targetOffset, 0);
                float mag = selection.GetComponent<Collider>().bounds.size.magnitude / scaleFactor;
                currentTargetInstance.transform.localScale = new Vector3(mag, mag, mag);
            }
        }

        public void OnSelect(Transform transform, RaycastHit hitInfo)
        {
        }

        private void OnDestroy()
        {
            if (currentTargetInstance != null)
                Destroy(currentTargetInstance);
        }
    }
}