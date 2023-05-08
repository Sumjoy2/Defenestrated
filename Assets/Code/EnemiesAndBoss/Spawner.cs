using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 1.0f;
    public float timeBetweenWaves = 5.0f;

    public int enemyCount;
    public int waveCount = 0;
    public GameObject enemy;
    bool waveIsDone = true;

    void Update()
    {
        //if spawn reaches 4, then stop spawning so player can fight boss
        if(waveIsDone == true)
        {
            StartCoroutine(waveSpawner());
        }
    }

    IEnumerator waveSpawner()
    {
        
        if(waveCount <= 5)
        {
            waveIsDone = false;

            for (int i = 0; i < enemyCount; i++)
            {
                GameObject enemyClone = Instantiate(enemy, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(spawnRate);
            }

            spawnRate -= 0.1f;
            enemyCount += 3;
            waveCount += 1;

            yield return new WaitForSeconds(timeBetweenWaves);

            waveIsDone = true;
        }
        
    }
    
}
