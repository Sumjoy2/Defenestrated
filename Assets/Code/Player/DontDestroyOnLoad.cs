using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    /*    public static Player Instance;*/
    public static GameObject test;
    // Start is called before the first frame update
    void Start()
    { 
        if (test != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else if (test == null)
        {
            test = this.gameObject;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frameS
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            Destroy(this.gameObject);
            return;
        }
    }
}
