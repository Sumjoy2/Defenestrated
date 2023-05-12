using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    public Image grenade;
    public float coolDown = 3f;
    bool isCoolDown = false;
    public Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        grenade.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Cool();
    }

    void Cool()
    {
        if (player.grenadeOnCooldown == true && isCoolDown == false)
        {
            isCoolDown = true;
            grenade.fillAmount = 1;
        }

        if (isCoolDown)
        {
            grenade.fillAmount -= 1 / coolDown * Time.deltaTime;

            if(grenade.fillAmount <= 0)
            {
                grenade.fillAmount = 0;
                isCoolDown = false;
            }
        }
    }
}
