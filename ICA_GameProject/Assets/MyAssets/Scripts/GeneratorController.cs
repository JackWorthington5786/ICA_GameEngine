using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorController : MonoBehaviour
{
    public GameObject canvas;
    public GameObject orb;
    public Button button;

    void Start()
    {
        CloseCanvas();
        
        button.onClick.AddListener(() => ToggleGen());
        
        //hide the orb
        orb.SetActive(false);
    }
    
    void CloseCanvas()
    {
        if (canvas != null)
        {
            canvas.SetActive(false);
            Time.timeScale = 1f; // Resume the game
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenCanvas();
        }
    }
    
    void OpenCanvas()
    {
        if (canvas != null)
        {
            canvas.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
    }
    
    void ToggleGen()
    {
        //show the orb
        orb.SetActive(true);
        
        //hide the canvas
        CloseCanvas();
    }

}
