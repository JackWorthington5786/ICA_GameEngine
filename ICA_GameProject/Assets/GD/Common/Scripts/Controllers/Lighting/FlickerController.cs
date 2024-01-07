using System.Collections;
using UnityEngine;

public class FlickerController : MonoBehaviour
{
    [SerializeField]
    private bool IsFlickering;

    [SerializeField]
    [Range(0.01f, 100)]
    private float timeDelay;

    private Light currentLight;

    private void Awake()
    {
        currentLight = gameObject.GetComponent<Light>();
    }

    private void Update()
    {
        if (IsFlickering)
        {
            StartCoroutine(FlickerLight());
        }
    }

    private IEnumerator FlickerLight()
    {
        IsFlickering = true;
        currentLight.enabled = false;
        currentLight.intensity = 0.5f;
        timeDelay = Random.Range(0.01f, 0.1f);
        yield return new WaitForSeconds(timeDelay);
        currentLight.enabled = true;
        currentLight.intensity = 1f;
        timeDelay = Random.Range(0.01f, 0.1f);
        yield return new WaitForSeconds(timeDelay);
        IsFlickering = false;
    }
}