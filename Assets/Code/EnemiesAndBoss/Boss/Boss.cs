using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boss : MonoBehaviour
{
    [Header("HealthStuff")]
    public bool isInvincible = false;
    public int helthMax = 1000;
    public int helthCurrent;
    public HealthBar healthBar;
    public TextMeshProUGUI HPText;

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
     * 2 = laserr
     */

    [Header("TeleportStuff")]
    public float cooldownTeleport = 10.0f; // How often boss teleports
    public float teleportTime; //Teleportation timer
    //public bool canTeleport; // ability to teleport

    [Header("Win")]
    public GameObject Win; //allows win

    Rigidbody2D rigidbody2d; //rigidbody
    Animator animator;

    GameObject player;
    private Player playerScip;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // makes rigidbody work
        animator = GetComponent<Animator>();

        player = GameObject.Find("Player");
        playerScip = player.GetComponent<Player>();

        //sets health bar and health
        helthCurrent = helthMax;
        healthBar.SetMaxHealth(helthMax);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        //attack timer. Going to randomly select an attack from array
        if (timerTimer <= 0f)
        {
            //Randomly Selects 1 attack from the attack list
            randomattak = Random.Range(0, attacks.Length);

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

        //enters phase 2 when at half health
        if (helthCurrent <= helthMax / 2)
        {
            animator.SetBool("Angy", true);
        }

        //win game when boss health 0
        if (helthCurrent <= 0)
        {
            //load scene win
            PauseGame();
            Win.SetActive(true);
            return;
        }
    }

    //When the boss gets hit by something do this
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        { 
            TakeDamage(playerScip.damage);
        }
        
    }

    //if it touches the grenade, it takes dmg
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Grenade"))
        {
            TakeDamage(50);
        }
    }

    //boss takes damage, updates health bar
    public void TakeDamage(int dmg)
    {
        if (isInvincible == true)
        {
            return;
        }

        helthCurrent -= dmg;
        HPText.text = helthCurrent.ToString();
        healthBar.SetHealth(helthCurrent);
    }

    // Currently setup to launch a im assuming fireball
    void LaunchFireBall()
    {
        GameObject fireball = Instantiate(attacks[0], transform.position, transform.rotation);//summons from boss local
        fireball.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3 (Random.Range(-range, range), -300, 0)); // makes go zoom
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
        teleportTime = cooldownTeleport;
        Debug.Log("Teleported");
    }

    //launch laser, smaller, faster, does more damage
    void Laser()
    {
        GameObject laser = Instantiate(attacks[2], transform.position, transform.rotation); //summons from boss local
        laser.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(Random.Range(-range, range), -450, 0)); // makes go zoom
        Debug.Log("LaserSent");
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
}
