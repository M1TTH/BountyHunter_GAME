using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;
    public GameObject HealthPack;
    public Transform HPSpawn;
    public GameObject UpgradeRifle;
    public Transform RifleSpawn;

    public void DeductHealth(float deductHealth)
    {
        enemyHealth -= deductHealth;

        if (enemyHealth <= 0)
        {
            if (Random.Range(0, 100) > 70) // 30% Chance
            {
                Instantiate(HealthPack, HPSpawn.position, HPSpawn.rotation);
            }
            if (Random.Range(0, 100) > 99) // 1% Chance
            {
                Instantiate(UpgradeRifle, RifleSpawn.position, RifleSpawn.rotation);
            }
            EnemyDead();
        }
    }

    void EnemyDead()
    {
        Destroy(gameObject);
    }
}
