using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofController : MonoBehaviour
{
    private float originalY;
    private Renderer objectRenderer;

    public float alphaMultiplier = 0.1f; // Adjust this value to control the rate of alpha decrease.

    void Start()
    {
        originalY = transform.position.y;
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer == null)
        {
            Debug.LogError("Object does not have a Renderer component!");
        }
    }

    void Update()
    {
        float currentY = transform.position.y;

        // Check if the Y position is greater than the original Y value
        if (currentY > originalY)
        {
            // Calculate alpha based on the difference in Y positions
            float alpha = 1.0f - (currentY - originalY) * alphaMultiplier;
            alpha = Mathf.Clamp01(alpha); // Ensure alpha is within [0, 1]

            // Update the object's material alpha
            UpdateAlpha(alpha);
        }
    }

    void UpdateAlpha(float alpha)
    {
        Color objectColor = objectRenderer.material.color;
        objectColor.a = alpha;
        objectRenderer.material.color = objectColor;
    }
}
