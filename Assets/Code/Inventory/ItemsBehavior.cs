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

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Destroy(gameObject);
    }

    public void UseGun()
    {
        //gun.transform.SetParent(player.transform.parent);
        //player.transform.parent = gun.transform;
        //player.transform.localPosition = Vector2.zero;

        //Instantiate(gun, player.position, player.transform, player);
        //gun.transform.SetParent(player.transform.parent);
        Destroy(gameObject);


    }
}
