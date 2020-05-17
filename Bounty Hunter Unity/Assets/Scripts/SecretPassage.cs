using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretPassage : MonoBehaviour
{
    public GameObject SecretPassageTriggerBoss;
    public GameObject SecretPassageCover;
    public GameObject BossRoomCover;
    public GameObject BossSecretDoor;
    public GameObject BossShield;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.GetComponent<BoxCollider>().enabled = false;
            SecretPassageCover.SetActive(false);
            SecretPassageTriggerBoss.SetActive(true);
            BossRoomCover.SetActive(false);
            BossSecretDoor.SetActive(false);
            BossShield.SetActive(true);
        }
    }
}
