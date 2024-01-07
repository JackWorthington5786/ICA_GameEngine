using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemMovment : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField]
    private Vector3 rotatationAxis;

    [SerializeField]
    private float rotationAngleInDegs;

    [SerializeField]
    private Space rotationSpace;
    
    
    [Header("Hover")]
    [SerializeField] float hoverAmplitude = 0.5f;
    public float hoverHight = 0.5f;
    
    
    // Update is called every frame, if the MonoBehaviour is enabled
    private void Update()
    {
        gameObject.transform.Rotate(rotatationAxis, rotationAngleInDegs,
            rotationSpace);
        
        // add the sine wave to the y position
        transform.position = new Vector3(transform.position.x,
            Mathf.Sin(Time.time) * hoverAmplitude + hoverHight,
            transform.position.z);
    }
    
}

