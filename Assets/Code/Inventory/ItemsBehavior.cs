using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;

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
    public float speed = 5;

    
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
        

        if (Input.GetKeyDown(key))
        {
            button.onClick.Invoke();
        }
    }

    //heals player when heal is used in inventory
    public void UseHealth()
    {
        player.TakeDamage(-20);
        Destroy(gameObject);
    }

    public void UseGranade()
    {
        Instantiate(granade, playerObj.transform.position, Quaternion.identity);
        speed -= Random.Range(.1f, .25f);
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);      
        Destroy(gameObject);
    }

    public void UseGun()
    {
        Destroy(GameObject.FindWithTag("Player"));
        playerWithGun = Instantiate(playerWithGun, playerObj.transform.position, Quaternion.identity);        
        Destroy(gameObject);
        
    }
}
