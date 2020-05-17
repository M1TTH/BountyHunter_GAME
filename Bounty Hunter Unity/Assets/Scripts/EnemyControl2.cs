using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyControl2 : MonoBehaviour
{
    public bool canSeePlayer = false;
    public Transform target;
    public Transform Enemy;
    public float distanceBetween;
    private NavMeshAgent nav;
    public LayerMask layerMask;
    public float fieldOfViewRange = 45f;
    public float hearingRange = 5;
    public float weaponRange = 20;
    public bool isPatrolling = true;
    public List<GameObject> myPathPoints;
    public GameObject myPath;
    public int currentPoint = 0;
    public float rangeToPoint = 3;
    public GameObject bullet;
    public Transform firepos;
    public Transform firepos2;
    public Transform firepos3;
    public Transform firepos4;
    public Transform firepos5;

    public Vector3 lastKnownPosition;
    public bool hasSeenPlayer;
    public float bulletSpeed = 100;
    public bool canFire = true;
    public float firingRate = 1f;

    void Start()
    {
        this.target = GameObject.FindWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        nav.isStopped = true;
        myPathPoints = new List<GameObject>();
        myPathPoints = myPath.GetChildren();
    }


    void CheckingFiring()
    {

        if (canSeePlayer == false)
        {

            return;
        }

        float distance = Vector3.Distance(transform.position, target.position);
        if (weaponRange >= distance && canFire == true)
        {

            canFire = false;


            Invoke("FireAgain", firingRate);

            transform.LookAt(target.position);

            GameObject bul = Instantiate(bullet, firepos.position, firepos.rotation);
            GameObject bul2 = Instantiate(bullet, firepos2.position, firepos2.rotation);
            GameObject bul3 = Instantiate(bullet, firepos3.position, firepos3.rotation);
            //GameObject bul4 = Instantiate(bullet, firepos4.position, firepos4.rotation);
            //GameObject bul5 = Instantiate(bullet, firepos5.position, firepos5.rotation);


            bul.GetComponent<Rigidbody>().AddForce(bul.transform.forward * bulletSpeed);
            bul2.GetComponent<Rigidbody>().AddForce(bul2.transform.forward * bulletSpeed);
            bul3.GetComponent<Rigidbody>().AddForce(bul3.transform.forward * bulletSpeed);
            //bul4.GetComponent<Rigidbody>().AddForce(bul4.transform.forward * bulletSpeed);
            //bul5.GetComponent<Rigidbody>().AddForce(bul5.transform.forward * bulletSpeed);
        }

    }
    void FireAgain()
    {
        canFire = true;
    }
    void Update()
    {
        CheckPOV();

        CheckingFiring();

        distanceBetween = Vector3.Distance(Enemy.transform.position, target.transform.position);

        if (distanceBetween <= 5 && canSeePlayer == true)
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
        }

        if (distanceBetween > 5 && canSeePlayer == true)
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
        }
        if (canSeePlayer == false)
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
        }

        if (canSeePlayer == true)
        {
            nav.isStopped = false;
            nav.SetDestination(target.position);
            lastKnownPosition = target.position;
        }
        else
        {

            if (isPatrolling && hasSeenPlayer == false)


            {
                nav.isStopped = false;
                nav.SetDestination(myPathPoints[currentPoint].transform.position);

                if (Vector3.Distance(transform.position, myPathPoints[currentPoint].transform.position) < rangeToPoint)
                    currentPoint += 1;

                if (currentPoint > myPathPoints.Count - 1)
                    currentPoint = 0;
            }

            else
            {

                if (Vector3.Distance(transform.position, lastKnownPosition) < 1
                    || hasSeenPlayer == false)
                {
                    nav.isStopped = true;
                    if (isPatrolling)
                    {

                        float closest = 9999;
                        int whoWasClosest = 0;

                        for (int whichPoint = 0; whichPoint < myPathPoints.Count; whichPoint++)
                        {

                            float distance = Vector3.Distance(transform.position,
                                myPathPoints[whichPoint].transform.position);
                            if (distance < closest)
                            {
                                closest = distance;
                                whoWasClosest = whichPoint;
                            }
                        }
                        currentPoint = whoWasClosest;
                        hasSeenPlayer = false;
                    }
                }
                else
                {

                    nav.isStopped = false;
                    nav.SetDestination(lastKnownPosition);
                }


            }

        }


    }


    void CheckPOV()
    {

        Vector3 direction = target.position - transform.position;
        Ray ray = new Ray(transform.position, direction);

        float distance = Vector3.Distance(target.position, transform.position);


        Debug.DrawRay(transform.position, direction, new Color(1, 1, 0));

        if (!Physics.Raycast(ray, distance, layerMask))
        {

            if (Vector3.Angle(ray.direction, transform.forward) < fieldOfViewRange)
            {
                canSeePlayer = true;
                hasSeenPlayer = true;
            }

        }
        else
        {
            canSeePlayer = false;
        }

        if (canSeePlayer == false)
        {
            if (Vector3.Distance(transform.position, target.position) < hearingRange)
            {
                canSeePlayer = true;
                hasSeenPlayer = true;

            }
        }

    }
}



