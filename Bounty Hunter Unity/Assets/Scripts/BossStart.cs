using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStart : MonoBehaviour
{
    public GameObject SecretBossDoor;
    public GameObject BossSmallGuns;
    public GameObject Boss;
    public GameObject UpgradedEnemySpawners;
    public GameObject BossDoor;
    public GameObject SecretBossTrigger;




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.GetComponent<BoxCollider>().enabled = false;
            SecretBossDoor.SetActive(true);
            BossSmallGuns.SetActive(true);
            Boss.GetComponent<BossScript>().enabled = true;
            UpgradedEnemySpawners.SetActive(true);
            BossDoor.SetActive(true);
            SecretBossTrigger.SetActive(false);

        }
    }
}