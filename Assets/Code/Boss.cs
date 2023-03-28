using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    float invincibleTimer; // So Boss cant get hit in quick succession
    public float timerTimer = 5; // initial attack cooldown
    public float timeTime = 5.0f; // how often attack

    public int range; // range of attacks
    public GameObject[] attacks; // array for attacks
    /* important attack array info
     * 0 = projectile
     * 1 = enemy
     * 
     */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //attack timer. Going to randomly select an attack from array
        if (timerTimer <= 0f)
        {
            //Randomly Selects 1 attack from the attack list
            int i;
            i = Random.Range(0, attacks.Length);
            if (i == 0)
            {
                LaunchFireBall();
            }
            else if (i == 1)
            {
                SummonEnemies();
            }
            timerTimer = timeTime;
        }
        //timer countdown
        else if (timerTimer > 0)
        {
            timerTimer -= Time.deltaTime;
        }
    }

    //When the boss gets hit by something do this
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Boss Got Hit", other.otherCollider);
    }

    // Currently setup to launch a projectile
    void LaunchFireBall()
    {
        GameObject fireball = Instantiate(attacks[0], transform.position, transform.rotation); //summons from boss local
        fireball.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(300, Random.Range(-range, range), 0)); // makes go zoom
        Debug.Log("FireBallSent");
    }
    
    //setup to summon enemies
    void SummonEnemies()
    {
        GameObject enemy = Instantiate(attacks[1], transform.position , transform.rotation); //summons on bosses location
        enemy.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(0, Random.Range(-range, range), 0)); // go less zoom
        Debug.Log("EmemySpawned");
    }
}
