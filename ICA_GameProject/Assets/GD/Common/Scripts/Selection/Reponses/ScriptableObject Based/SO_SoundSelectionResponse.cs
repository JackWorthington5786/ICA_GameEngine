using System;
using UnityEngine;

namespace GD.Selection
{
    /// <summary>
    /// Plays an audio clip on first new selection (i.e. previous selection was null or different object) of an appropriate game object
    /// SO versions of the ISelectResponse classes that previously were implemented as MonoBehaviours
    /// This allows us to drag and drop multiple selection responses into a List<ISelectResponse> in the AdvancedSelectionManager
    /// </summary>
    [CreateAssetMenu(fileName = "SO_SoundSelectionResponse", menuName = "DkIT/Scriptable Objects/Other/Responses/Sound")]
    [Serializable]
    public class SO_SoundSelectionResponse : ScriptableObject, ISelectionResponse
    {
        [SerializeField]
        private AudioClip selectedAudioClip;

        private Transform currentTransform = null;

        public void OnDeselect(Transform transform)
        {
        }

        public void OnSelect(Transform transform)
        {
            //is this game object a new selection? this prevents the "wall of sound" with same clip played multiple times
            if (currentTransform != transform)
                AudioSource.PlayClipAtPoint(selectedAudioClip, transform.position);

            currentTransform = transform;
        }

        public void OnSelect(Transform transform, RaycastHit hitInfo)
        {
        }
    }
}