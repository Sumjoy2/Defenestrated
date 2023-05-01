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
        //if (Input.GetButtonDown("Fire1"))
        //{
            //Fire();
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
            }
            if (Input.GetButtonUp("Fire1"))
            {
                StopFire();
            }
        //}          
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
