using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    //variables
    public GameObject gameOverCanvas;
    
    //on start hide the game over canvas
    void Start()
    {
        gameOverCanvas.SetActive(false);
    }
    
    //Reset scene
    public void ResetScene()
    {
        // Reload the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
