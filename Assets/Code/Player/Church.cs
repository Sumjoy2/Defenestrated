using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Church : MonoBehaviour
{
    private GameObject player;

    private Spawner spawnScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnScript = GameObject.FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(spawnScript.waveCount > 5)
            {
                SceneManager.LoadScene("Bossfight");
            }
            
            //player.position = targetPosition;
        }
    }
}
