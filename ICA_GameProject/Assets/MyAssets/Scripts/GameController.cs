using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject gameOverCanvas;
    
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
