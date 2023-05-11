using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ItemsBehavior : MonoBehaviour
{
    private Player player;

    public KeyCode key;
    private Button button;
    
    public GameObject granade;
    public GameObject playerWithGun;
    public GameObject bullet;

    private Vector3 targetPos;
    private GameObject playerObj;
        
    
    void Awake()
    {
        button = GetComponent<Button>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //targetPos = GameObject.Find("Player").transform.position;
        playerObj = GameObject.Find("Player");
        targetPos = playerObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }    
    
    
    //heals player when heal is used in inventory
    public void UseHealth()
    {
        if (player.curHealth < 100)
        {
            player.TakeDamage(-20);
            Destroy(gameObject);
        }
        else
        {
            return;
        }
        
    }

    public void UseGranade()
    {
        
        
        
        
       
        //Destroy(gameObject);
    }

    public void UseGun()
    {
        Destroy(GameObject.FindWithTag("Player"));
        playerWithGun = Instantiate(playerWithGun, playerObj.transform.position, Quaternion.identity);        
        Destroy(gameObject);
        
    }
}
