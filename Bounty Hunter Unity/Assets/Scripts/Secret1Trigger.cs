using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret1Trigger : MonoBehaviour
{
    public GameObject Secret1Cover;




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.GetComponent<BoxCollider>().enabled = false;
            Secret1Cover.SetActive(false);


        }
    }
}
