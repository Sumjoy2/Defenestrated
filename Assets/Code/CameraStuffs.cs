using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraStuffs : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        player = GameObject.FindGameObjectWithTag("Player");
        vcam.Follow = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
