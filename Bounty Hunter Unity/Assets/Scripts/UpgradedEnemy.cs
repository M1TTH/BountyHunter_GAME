using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradedEnemy : MonoBehaviour
{
    public float firingRate = 0.5f;
    public GameObject laser;
    public Transform firePos1;
    public float BulletForce = 250f;
    public float rangeToTarget = 200f;
    public Transform myTarget;
    public float angleToFire = 15f;
    public float BulletDel = 1f;
    public Transform target;
    public float turnSpeed = 1f;
    public bool hasbeenHit = false;


    void Update()
    {
        FaceTarget();
    }

    void FaceTarget()
    {

        Quaternion currentAngle = transform.rotation;

        transform.LookAt(target);
        Quaternion desiredAngle = transform.rotation;

        transform.rotation = Quaternion.Lerp(currentAngle, desiredAngle, turnSpeed * Time.deltaTime);
    }

    void Start()
    {
        InvokeRepeating("TestFiring", firingRate, firingRate);
    }


    void TestFiring()
    {
        if (Vector3.Distance(transform.position, myTarget.position) > rangeToTarget) return;

        Vector3 targetDir = myTarget.position - transform.position;

        float angle = Vector3.Angle(transform.forward, targetDir);

        if (angle > angleToFire) return;

        if (Random.Range(0, 10) > 1) //30% chance
        {
            transform.LookAt(myTarget);
        }

        GameObject bul1 = Instantiate(laser, firePos1.position, firePos1.rotation);

        bul1.GetComponent<Rigidbody>().AddForce(bul1.transform.forward * BulletForce, ForceMode.Impulse);

        Destroy(bul1, BulletDel);
    }
}

