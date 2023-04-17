using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;


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
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        return true;
    }

    public bool StopFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        return false;
    }

}
