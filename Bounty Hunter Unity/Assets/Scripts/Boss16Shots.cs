using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss16Shots : MonoBehaviour
{
    
    public float fireRate = 15f;
    public float nextTimeToFire = 0f;

    public Transform firePos1;
    public float BulletForce = 250f;
    public float BulletDel = 1f;

    public float frequency = 10f;
    public GameObject BossBullet;
    // Use this for initialization
    void Start()
    {
        Invoke("SpawnOne", frequency);
        //GameObject bul1 = Instantiate(BossBullet, transform.position, transform.rotation) as GameObject;
    }

    // Update is called once per frame
    void SpawnOne()
    {
       // GameObject obj = Instantiate(BossBullet, transform.position, transform.rotation) as GameObject;

        GameObject bul1 = Instantiate(BossBullet, firePos1.position, firePos1.rotation);

        bul1.GetComponent<Rigidbody>().AddForce(bul1.transform.forward * BulletForce, ForceMode.Impulse);
        Destroy(bul1, BulletDel);
        Invoke("SpawnOne", frequency);

    }
}

