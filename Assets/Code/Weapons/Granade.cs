using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Random = UnityEngine.Random;

public class Granade : MonoBehaviour
{
    private Vector3 targetPos;
    public float speed = 5;

    public GameObject explosion;

    void Start()
    {
        targetPos = GameObject.Find("FirePoint").transform.position;
    }
    
    void Update()
    {       

        if (speed > 0)
        {
            speed -= Random.Range(.001f, .0025f);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
        else if (speed < 0)
        {
            speed = 0;
            StartCoroutine(Explode(1));
        }


    }  
        
    
    IEnumerator Explode(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy") StartCoroutine(Explode(0));
    }
    
}
