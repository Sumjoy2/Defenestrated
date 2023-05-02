using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public int dmg = 20;
    GameObject player;
    private Player playerScrip;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScrip = player.GetComponent<Player>();
    }

    public void damagePlayer()
    {
        playerScrip.curHealth = playerScrip.curHealth - dmg;
        playerScrip.healthBar.SetHealth(playerScrip.curHealth);
    }
}
