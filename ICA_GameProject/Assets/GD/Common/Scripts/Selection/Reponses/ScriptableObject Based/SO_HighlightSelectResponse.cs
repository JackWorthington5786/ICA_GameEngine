using System;
using UnityEngine;

namespace GD.Selection
{
    /// <summary>
    /// Sets a highlight material (based on a user-defined material) on selection of an appropriate game object
    /// SO versions of the ISelectResponse classes that previously were implemented as MonoBehaviours
    /// This allows us to drag and drop multiple selection responses into a List<ISelectResponse> in the AdvancedSelectionManager
    /// </summary>
    [CreateAssetMenu(fileName = "SO_HighlightSelectionResponse", menuName = "DkIT/Scriptable Objects/Other/Responses/Highlight")]
    [Serializable]
    public class SO_HighlightSelectionResponse : ScriptableObject, ISelectionResponse
    {
        [SerializeField]
        [Tooltip("Set selected (highlighted) material for game object")]
        private Material selectedMaterial;

        private Material currentOriginalMaterial;

        public void OnDeselect(Transform selection)
        {
            var renderer = selection.GetComponent<Renderer>();

            //we can use c# 7.0 syntax -https://www.thomasclaudiushuber.com/2020/03/12/c-different-ways-to-check-for-null/"/>
            if (renderer != null && currentOriginalMaterial != null)
                renderer.material = currentOriginalMaterial;
        }

        public void OnSelect(Transform selection)
        {
            var renderer = selection.GetComponent<Renderer>();
            if (renderer != null)
            {
                currentOriginalMaterial = renderer.material;
                renderer.material = selectedMaterial;
            }
        }

        public void OnSelect(Transform transform, RaycastHit hitInfo)
        {
        }
    }
}