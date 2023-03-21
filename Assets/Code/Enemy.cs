using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public int totalHealth = 100;
    public int damage = 20;
    private float speed = 3f;


    public Transform player;
    private Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        Debug.Log(direction);
        direction.Normalize();
        movement = direction;
    }

    void FixedUpdate()
    {
        CharMovement(movement);
    }

    void CharMovement(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    public void Damage()
    {
        totalHealth -= damage;

        if (totalHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
