using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public bool isInvincible = false;

    [Header("TimerStuff")]
    public float timerTimer = 5; // initial attack cooldown
    public float timeTime = 5.0f; // how often attack
    float invincibleTimer; // So Boss cant get hit in quick succession

    [Header("0 = projectile, 1 = enemy, 2 = teleport, 3 = laser")]
    public GameObject[] attacks; // array for attack
    public int randomattak; // showing what attack is gonna happen
    public int range; // range of attacks
    /* important attack array info
     * 0 = projectile
     * 1 = enemy
     * 2 = teleport
     * 3 = laserr
     */

    [Header("TeleportStuff")]
    public float cooldownTeleport = 10.0f; // How often boss teleports
    public float teleportTime; //Teleportation timer
    public bool canTeleport; // ability to teleport

    Rigidbody2D rigidbody2d; //rigidbody
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // makes rigidbody work
    }

    // Update is called once per frame
    void Update()
    {
        //attack timer. Going to randomly select an attack from array
        if (timerTimer <= 0f)
        {
            //Randomly Selects 1 attack from the attack list
            randomattak = Random.Range(0, attacks.Length);
            //fireball
            if (randomattak == 0)
            {
                LaunchFireBall();
            }
            //suommon enemy
            else if (randomattak == 1) 
            {
                SummonEnemies();
            }
            //teleportation
            else if (canTeleport == true && randomattak == 2 && teleportTime <= 0)
            {
                Teleport();
                Debug.Log("Teleported");
            }
            timerTimer = timeTime;
        }
        //timer countdown
        else if (timerTimer > 0)
        {
            timerTimer -= Time.deltaTime;
        }
        //teleport timer countdown
        if (teleportTime > 0)
        {
            teleportTime -= Time.deltaTime;
        }
    }

    //When the boss gets hit by something do this
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Boss Got Hit" + other.otherCollider);
    }

    // Currently setup to launch a im assuming fireball
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
        rigidbody2d.position = Random.insideUnitCircle * 5;
        Debug.Log("Teleported");
        teleportTime = cooldownTeleport;
    }

    //launch laser, smaller does more damage
    void laser()
    {
        GameObject fireball = Instantiate(attacks[3], transform.position, transform.rotation); //summons from boss local
        fireball.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(300, Random.Range(-range, range), 0)); // makes go zoom
        Debug.Log("LaserSent");
    }
}
