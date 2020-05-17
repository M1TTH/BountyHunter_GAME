using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondKey : MonoBehaviour
{
    public GameObject BossDoor;
    public GameObject SecondAreaDoor;
    public GameObject Key2;
    public GameObject BossActiveTrigger;
    public GameObject BossCover;
    public GameObject BossShield;




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.GetComponent<BoxCollider>().enabled = false;
            BossDoor.SetActive(false);
            SecondAreaDoor.SetActive(true);
            Key2.SetActive(false);
            BossActiveTrigger.SetActive(true);
            BossCover.SetActive(false);
            BossShield.SetActive(true);


        }
    }
}
