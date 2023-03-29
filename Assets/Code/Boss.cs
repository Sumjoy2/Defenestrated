using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Rigidbody2D rigidbody2d; //rigidbody

    [Header("TimerStuff")]
    float invincibleTimer; // So Boss cant get hit in quick succession
    public float timerTimer = 5; // initial attack cooldown
    public float timeTime = 5.0f; // how often attack

    [Header("AttackStuff")]
    public int range; // range of attacks
    public GameObject[] attacks; // array for attacks
    public int randomattak;

    [Header("TeleportStuff")]
    public float cooldownTeleport = 10.0f; // How often boss teleports
    public float teleportTime; //Teleportation timer
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
            randomattak = Random.Range(0, attacks.Length);
            if (randomattak == 0) // fireball
            {
                LaunchFireBall();
            }
            else if (randomattak == 1) //suommon enemy
            {
                SummonEnemies();
            }
            //teleportation
            else if (randomattak == 2)
            {
                Teleport();
                teleportTime = cooldownTeleport;
                Debug.Log("Teleported");
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

    //Boss Will teleport to random local
    void Teleport()
    {
        transform.position = Random.insideUnitCircle *5;
        Debug.Log("Teleported");
    }
}
