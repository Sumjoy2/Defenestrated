using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    private Player playerScip;
    GameObject bullet;
    public float speed = 2f;
    private Rigidbody2D rb;
    private Vector3 movement;

    //health
    public int maxHealth = 100;
    public int curHealth;
    public int damage = 20;

    private bool explosion;

    public GameObject healing;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerScip = player.GetComponent<Player>();

        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        //Vector3 direction = player.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        //direction.Normalize();
        //movement = direction;

        if(player!= null)
        {
            moveCharacter();
        }


        if (curHealth <= 0)
        {
            Destroy(gameObject);
            int q = Random.Range(1, 100);
            if (q > 25)
            {
                Instantiate(healing, transform.position, Quaternion.identity);
            }
        }
    }

    void FixedUpdate()
    {
        //moveCharacter(movement);
    }

    void moveCharacter(/*Vector2 direction*/)
    {
        movement = (player.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);

        //rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile") || other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(playerScip.damage);
        }               
    }

    public void TakeDamage(int dmg)
    {
        curHealth -= dmg;

        if (!explosion)
        {          
            curHealth -= 100;
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(.2f);
        explosion = false;
    }
}