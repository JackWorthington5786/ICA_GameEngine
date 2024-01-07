using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzelController : MonoBehaviour
{
    //canvas for the puzzle
    public GameObject canvas;
    
    //buttons for the puzzle
    [Header("UI elements")]
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    
    //indicators for the buttons
    public GameObject[] indicators;
    
    //panels for the puzzle
    public GameObject[] panels;
    public Color defaultColor = Color.white;
    public Color activeColor = Color.green;

    //doors coreesponding to the panels variables
    [Header("Doors")]
    public GameObject[] doors;
    public float displacment;
    
    //what doors are opened for each button
    [Header("Combos")]
    public int[] combo1;
    public int[] combo2;
    public int[] combo3;
    public int[] combo4;
    
    //on start hide the buttons and canvas
        void Start()
        {
            //hide the buttons
            button1.gameObject.SetActive(false);
            button2.gameObject.SetActive(false);
            button3.gameObject.SetActive(false);
            button4.gameObject.SetActive(false);
            
            // Attach the button click events to the respective methods
            button1.onClick.AddListener(() => ToggleDoors(combo1, 1));
            button2.onClick.AddListener(() => ToggleDoors(combo2, 2));
            button3.onClick.AddListener(() => ToggleDoors(combo3, 3));
            button4.onClick.AddListener(() => ToggleDoors(combo4, 4));
            
            // Set the default color for all panels
            SetstartingColor();
            //hide the canvas
            CloseCanvas();
        }

        //when the player enters the trigger show the buttons
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //show the canvas
                OpenCanvas();
                //show buttons
                button1.gameObject.SetActive(true);
                button2.gameObject.SetActive(true);
                button3.gameObject.SetActive(true);
                button4.gameObject.SetActive(true);
            }
        }
        
        //when the player exits the trigger hide the buttons (this allows me to use the same canvas for multiple puzzles parts)
        void OnTriggerExit(Collider other)
        {
            //hide the canvas
            if (other.CompareTag("Player"))
            {
                button1.gameObject.SetActive(false);
                button2.gameObject.SetActive(false);
                button3.gameObject.SetActive(false);
                button4.gameObject.SetActive(false);
            }
        }
    
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CloseCanvas();
            }
        }
    
        // Open and close the canvas
        void OpenCanvas()
        {
            if (canvas != null)
            {
                canvas.SetActive(true);
                Time.timeScale = 0f; // Pause the game
            }
        }
    
        // Close the canvas
        void CloseCanvas()
        {
            if (canvas != null)
            {
                canvas.SetActive(false);
                Time.timeScale = 1f; // Resume the game
            }
        }
    
        // Toggle the doors based on the button pressed
        void ToggleDoors(int[] panelIndices, int buttonIndex)
        {   
            // Toggle the color of the indicator
            Image indicatorsImage = indicators[buttonIndex - 1].GetComponent<Image>();
            indicatorsImage.color = (indicatorsImage.color == defaultColor) ? activeColor : defaultColor;
            
            // Toggle the color of the panel
            foreach (int index in panelIndices)
            {
                if (index >= 1 && index <= panels.Length)
                {
                    Image panelImage = panels[index - 1].GetComponent<Image>();

                    // Toggle the color of the panel
                    panelImage.color = (panelImage.color == defaultColor) ? activeColor : defaultColor;

                    // Move the corresponding door based on the panel's state
                    MoveDoor(index - 1, panelImage.color == activeColor);
                }
            }
        }
        
        // Move the door up or down based on the panel's state
        void MoveDoor(int doorIndex, bool isActive)
        {
            if (doorIndex >= 0 && doorIndex < doors.Length)
            {
                doors[doorIndex].transform.position += new Vector3(0f, isActive ? displacment : -displacment, 0f);
            }
        }
        
        // Set the default color for all panels
        void SetstartingColor()
        {
            foreach (GameObject panel in panels)
            {
                panel.GetComponent<Image>().color = activeColor;
            }
            foreach (GameObject indicator in indicators)
            {
                indicator.GetComponent<Image>().color = defaultColor;
            }
        }
}
