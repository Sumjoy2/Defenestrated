using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    float invincibleTimer;
    public float timerTimer = 5;
    public float timeTime = 5.0f;

    public int range;
    public GameObject[] attacks;


    // Start is called before the first frame update
    void Start()
    {
        //attacks = GameObject.FindGameObjectsWithTag("BossProt");
    }

    // Update is called once per frame
    void Update()
    {
        if (timerTimer <= 0f)
        {
            LaunchFireBall();
            timerTimer = timeTime;
        }
        else if (timerTimer > 0)
        {
            timerTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Boss Got Hit", other.otherCollider);
    }

    void LaunchFireBall()
    {
        GameObject fireball = Instantiate(attacks[0], transform.position, transform.rotation);
        fireball.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(300, Random.Range(-range, range), 0));
    }
}
