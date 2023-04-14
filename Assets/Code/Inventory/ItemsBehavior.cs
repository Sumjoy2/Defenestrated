using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Security.Permissions;
using UnityEngine;

public class ItemsBehavior : MonoBehaviour
{
    private Player player;
    
    public GameObject granade;
    public GameObject gun;
    public GameObject bullet;

    private Vector2 targetPos;
    public float speed = 5;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = GameObject.Find("Player").transform.position;
    }

    //heals player when heal is used in inventory
    public void UseHealth()
    {
        player.curHealth += 20;
        player.healthBar.SetHealth(player.curHealth);
        Destroy(gameObject);
    }

    public void UseGranade()
    {
        Instantiate(granade, transform.position, Quaternion.identity);
        //if(speed > 0)
       // {
            speed -= Random.Range(.1f, .25f);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
       // }else if(speed < 0)
       // {
          //  speed = 0;
       // }
        Destroy(gameObject);
    }

    /*public void UseGun()
    {
        //make it spawn in world/locat coordinate, test to see if it changes where the gun spawns
        GameObject go = Instantiate(gun, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        go.transform.parent = GameObject.Find("Player").transform;
        gameObject.tag = "PlayerProjectile";
        Destroy(gameObject);
    }*/
}
