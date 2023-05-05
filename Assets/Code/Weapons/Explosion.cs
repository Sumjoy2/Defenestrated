using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float radius = 3;

    private GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D col in enemyHit)
        {
            Enemy enemyHealth = col.GetComponent<Enemy>();
            if (enemyHealth != null)
            {
                //Enemy.TakeDamage(100);
            }
        }
    }
}
