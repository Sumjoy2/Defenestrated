using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    float invincibleTimer;
    float timerTimer = 5;

    public int range;
    public GameObject protFire;
    public GameObject prot2;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timerTimer <= 2.5f)
        {
            LaunchFireBall();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Boss Got Hit", other.otherCollider);
    }

    void LaunchFireBall()
    {
        GameObject fireball = Instantiate(protFire, transform.position, transform.rotation);
        fireball.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(300, Random.Range(-range, range), 0));
    }
}
