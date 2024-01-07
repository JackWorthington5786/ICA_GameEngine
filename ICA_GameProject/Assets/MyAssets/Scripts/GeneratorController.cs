using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorController : MonoBehaviour
{
    //variables
    public GameObject canvas;
    public GameObject orb;
    public Button button;

    //on start hide the canvas and orb
    void Start()
    {
        CloseCanvas();
        
        button.onClick.AddListener(() => ToggleGen());
        
        //hide the orb
        orb.SetActive(false);
    }
    
    //close the canvas
    void CloseCanvas()
    {
        if (canvas != null)
        {
            canvas.SetActive(false);
            Time.timeScale = 1f; // Resume the game
        }
    }
    
    //open the canvas when the player enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenCanvas();
        }
    }
    
    //open the canvas 
    void OpenCanvas()
    {
        if (canvas != null)
        {
            canvas.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
    }
    
    //toggle the generator on and off
    void ToggleGen()
    {
        //show the orb
        orb.SetActive(true);
        
        //hide the canvas
        CloseCanvas();
    }

}
