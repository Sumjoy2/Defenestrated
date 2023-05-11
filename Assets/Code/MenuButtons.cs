using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    public GameObject loseCanvas;


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void DisableCanvas()
    {
        // Disable the Canvas GameObject
        SceneManager.LoadScene("Gaem");
        loseCanvas.SetActive(false);
    }
}