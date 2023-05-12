using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    public GameObject loseCanvas;
    GameObject player;
    private Player playerScip;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name != "Menu")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerScip = player.GetComponent<Player>();
        }
        
    }

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
        playerScip.curHealth = playerScip.maxHealth;
        playerScip.TakeDamage(0);
        player.transform.position =new Vector2 (0, 0);
        loseCanvas.SetActive(false);
    }
}