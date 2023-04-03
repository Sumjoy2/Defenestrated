using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //throws item away when player clicks X
    public void SpawnDroppedItem()
    {
        Vector2 playerpos = new Vector2(player.position.x, player.position.y + 2);
        Instantiate(item, playerpos, Quaternion.identity);
    }
}
