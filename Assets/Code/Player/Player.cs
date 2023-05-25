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

    [Header("HelthStuffs")]
    //HP stuff
    public int maxHealth = 100;
    //current player health
    public int curHealth;
    public int damage = 20;
    public bool ifInvincible = false;
    public HealthBar healthBar;
    public TextMeshProUGUI healthPoints;

    [Header("Other")]
    public bool Save;
    public float expirence = 0;
    public float speed = 3.5f;

    float generalTimer;
    float invincibleTimer;

    Rigidbody2D rigidbody2d;

    Vector2 moveDirection;
    Vector2 mousePosition;

    public GameObject granade;

    //delay for stupid grenade
    public bool grenadeOnCooldown = false;

    public GameObject lose;
    public GameObject playerStuff;

    AudioSource audioData;
    public AudioClip [] SFX_Clips;
    Scene theScene;

    // Start is called before the first frame update
    void Start()
    {

        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        curHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        lose.SetActive(false);

        audioData = GetComponent<AudioSource>();
       

        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else if (Instance == null && Save == true)
        {
            Instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }

        //saves player inventory/HUD elements 
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector2(horizontal, vertical).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);       

        if (horizontal != 0 || vertical != 0)
        {
            
            if (!audioData.isPlaying) audioData.Play(0);
        }
        else
        {
            audioData.Stop();

        }

        if (Input.GetKeyDown(KeyCode.Q) && !grenadeOnCooldown)
        {
            Instantiate(granade, transform.position, Quaternion.identity);
            StartCoroutine(KeyCooldown());
        }        

        //to be able to skip to boss
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene("Bossfight");
            transform.position = new Vector2(0, -3.7f);
        }

        //Destroys on game menu
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            Destroy(this.gameObject);
            return;
        }
    }

    void FixedUpdate()
    {
        // depending on scene, play diff sound clip
        theScene = SceneManager.GetActiveScene();
        if (theScene.name == "Gaem")
        {
            audioData.clip = SFX_Clips[0];  // grass
        }
        else if (theScene.name == "Bossfight")
        {
            audioData.clip = SFX_Clips[1];   // bricks
        }

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

    private IEnumerator KeyCooldown()
    {
        grenadeOnCooldown = true;

        // Replace 1f with your desired cooldown duration
        yield return new WaitForSeconds(3f);

        grenadeOnCooldown = false;
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

             //when player dies, game stops and u get a lose menu
            if (curHealth <= 0)
            {
                PauseGame();
                lose.SetActive(true);
                return;
            }
        }
              
    }

    //Does All Health Stuffs
    public void TakeDamage(int dmg)
    {

        if (ifInvincible)
        {
            return;
        }
        curHealth -= dmg;
        healthBar.SetHealth(curHealth);
        healthPoints.text = curHealth.ToString();
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
