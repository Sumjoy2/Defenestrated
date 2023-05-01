using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    /*    public static Player Instance;*/
    public static GameObject test;
    // Start is called before the first frame update
    void Start()
    {
        test = this.gameObject;
        if (test == null)
        {
            Destroy(this.gameObject);
            return;
        }
        else if (test != null)
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frameS
    void Update()
    {

    }
}
