using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossProjectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public int damage = 20;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // makes rigidbody work
    }

    // Update is called once per frame
    void Update()
    {
        //if position is futher than 75 deletes projectile
        if (transform.position.magnitude > 75.0f)
        {
            Destroy(gameObject);
        }
    }

    //when hits something deletes projectile
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("HitSomething");
        Destroy(gameObject);
    }
}
