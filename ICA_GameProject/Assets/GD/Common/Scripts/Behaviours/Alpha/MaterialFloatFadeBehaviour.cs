using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace GD
{
    /// <summary>
    /// Controls float value over time on a material for a MeshRenderer using coroutines and AnimationCurves.
    /// </summary>
    public class MaterialFloatFadeBehaviour : MonoBehaviour
    {
        [Space]
        [SerializeField]
        private MeshRenderer renderer = null;

        [SerializeField]
        private string materialPropertyReference = "_Alpha";

        [SerializeField]
        [Range(0f, 1f)]
        private float initialValue = 0;

        [SerializeField]
        [Range(0f, 1f)]
        private float finalValue = 1;

        [SerializeField]
        [Unit(Units.Second)]
        private float fadeDuration = 1;

        [FoldoutGroup("Curve & Events")]
        [SerializeField]
        private AnimationCurve easingCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        [FoldoutGroup("Curve & Events")]
        [SerializeField]
        private UnityEvent OnComplete;

        private Material material;
        private int propertyID;

        private void Start()
        {
            //StartFade();
        }

        /// <summary>
        /// Initiates the fade animation (transparent to opaque)
        /// </summary>
        [ContextMenu("Start Fade")]
        public void StartFade()
        {
            //Check for a renderer
            if (renderer != null)
                material = renderer.sharedMaterial;

            //Convert string to hash to reduce overhead
            propertyID = Shader.PropertyToID(materialPropertyReference);

            StartCoroutine(Fade());
        }

        /// <summary>
        /// Coroutine for handling fading animations.
        /// </summary>
        private IEnumerator Fade()
        {
            if (fadeDuration == 0)
                yield return null;

            float elapsedTime = 0f;
            material.SetFloat(propertyID, initialValue);
            while (elapsedTime < fadeDuration)
            {
                material.SetFloat(propertyID,
                    Mathf.Lerp(initialValue, finalValue,
                    easingCurve.Evaluate(elapsedTime / fadeDuration)));

                elapsedTime += Time.deltaTime;
                yield return null; // Wait for the next frame
            }

            //Notify on complete
            OnComplete?.Invoke();
        }

        /// <summary>
        /// Stops all coroutines when the MonoBehaviour is destroyed.
        /// </summary>
        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}