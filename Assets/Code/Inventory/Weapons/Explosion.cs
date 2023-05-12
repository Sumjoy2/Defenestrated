using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float radius = 3;
    public int dmg = 100;
    private GameObject Enemy;
    private GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        boss = GameObject.FindGameObjectWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        /*Collider2D[] enemyHit = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D col in enemyHit)
        {
            Enemy enemyHealth = col.GetComponent<Enemy>();
            if (enemyHealth != null)
            {
                //Enemy.TakeDamage(100);
            }
        }*/
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("HIT: " + other.gameObject.tag);
        if (other.gameObject.tag == ("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(dmg);
        }
        //TagNotWorkWhy
        if (other.gameObject.tag == ("Boss"))
        {
            Debug.Log("Explodied Boss");
            //Boss = GameObject.FindGameObjectWithTag("Boss");
            other.gameObject.GetComponent<Boss>().TakeDamage(dmg);
        }
    }

    public void DestroyTheExplosion()
    {
        Destroy(gameObject);
    }
}
