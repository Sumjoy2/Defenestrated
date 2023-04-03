using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBehavior : MonoBehaviour
{
    private Player player;
    
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
}
