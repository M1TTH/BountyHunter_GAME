using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPistol : MonoBehaviour
{
    //public Transform muzzlePos;
    //public Camera fpsCam;
    //public ParticleSystem muzzleFlash;
    //public GameObject impactEffect;
    //public GameObject Hands;
    public float nextTimeToFire = 0f;
    public GameObject laser;
    public Transform firePos1;
    public float BulletForce = 250f;
    public float BulletDel = 1f;
    public float fireRate = 15f;
    //public float damageEnemy = 34;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bul1 = Instantiate(laser, firePos1.position, firePos1.rotation);

        bul1.GetComponent<Rigidbody>().AddForce(bul1.transform.forward * BulletForce, ForceMode.Impulse);

        Destroy(bul1, BulletDel);
        {
            
        }
    }
}