using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmbush : MonoBehaviour
{
    public GameObject Door1;
    public GameObject Door2;
    public GameObject Door3;
    public GameObject Enemy;
    public GameObject AmbushDoor;
    public GameObject Door2ndArea;
    public GameObject Cover2ndArea;
    public GameObject Key;
    public GameObject Secret1;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.GetComponent<BoxCollider>().enabled = false;
            Door1.GetComponent<Animation>().Play("Door1Open");
            Door2.GetComponent<Animation>().Play("Door2Open");
            Door3.GetComponent<Animation>().Play("Door3Open");
            Enemy.SetActive(true);
            AmbushDoor.SetActive(true);
            Door2ndArea.SetActive(false);
            Cover2ndArea.SetActive(false);
            Key.SetActive(false);
            Secret1.GetComponent<MeshCollider>().enabled = false;

        }
    }
}
