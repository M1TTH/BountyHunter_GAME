using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightSpawner : MonoBehaviour
{

    public float frequency = 20f;
    public GameObject Enemy;
    // Use this for initialization
    void Start()
    {
        Invoke("SpawnOne", frequency);
        GameObject obj = Instantiate(Enemy, transform.position, transform.rotation) as GameObject;
    }

    // Update is called once per frame
    void SpawnOne()
    {
        GameObject obj = Instantiate(Enemy, transform.position, transform.rotation) as GameObject;

        Invoke("SpawnOne", frequency);
    }
}

