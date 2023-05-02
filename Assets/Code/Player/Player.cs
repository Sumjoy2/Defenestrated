using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player Instance;
    //public PauseMenu pause;

    float horizontal;
    float vertical;

    private GameObject playerWithGun;

    //HP stuff
    public int maxHealth = 100;
    //current player health
    public int curHealth;
    public int damage = 20;
    public HealthBar healthBar;

    public float expirence = 0;
    public float speed = 3.5f;

    float generalTimer;
    float invincibleTimer;
    bool isInvincible = false;

    Rigidbody2D rigidbody2d;

    Vector2 moveDirection;
    Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        curHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        

        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else if (Instance == null)
        {
            Instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }

        //playerWithGun = transform.FindChild("GunForPlayer");

        //saves player inventory/HUD elements 
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector2(horizontal, vertical).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        
        rigidbody2d.MovePosition(position);

        Vector2 aimDirection = mousePosition - rigidbody2d.position;
        //the fancy math stuff that makes gun face correct direction
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg -90f;
        //I dont understand why this works but when i put the quaternion into your equation it didnt - Sage
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BossProt") || other.gameObject.CompareTag("Enemy"))
        {
             if (other.gameObject.tag == "BossProt")
             {
                 TakeDamage(other.gameObject.GetComponent<bossProjectile>().damage);
             }
             else 
             {
                 TakeDamage(other.gameObject.GetComponent<Enemy>().damage);
             }

            if (curHealth <= 0)
            {
                PauseGame();
                /*
                if (Input.GetMouseButtonDown(0))
                {
                    gun.Fire() = false;
                }
                if (Input.GetMouseButtonUp(0))
                {
                    gun.Fire() = false;
                }
                */
            }
        }
              
    }

    void TakeDamage(int dmg)
    {
        if (isInvincible)
        {
            return;
        }
        curHealth -= dmg;
        healthBar.SetHealth(curHealth);
    }

    // https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
