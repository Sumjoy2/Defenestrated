using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;
    public int range;


    void Update()
    {
            //Fires da gun
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
        
    }

    public bool Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(Random.Range(-range, range), 300, 0)); // makes go zoom
        return true;
    }

    public bool StopFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(Random.Range(-range, range), 300, 0)); // makes go zoom
        return false;
    }

}
