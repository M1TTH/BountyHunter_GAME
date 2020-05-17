using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public float enemyHealth = 100f;


    public void DeductHealth(float deductHealth)
    {
        enemyHealth -= deductHealth;

        if (enemyHealth <= 0)
        {
            EnemyDead();
            SceneManager.LoadScene("BountyEliminated");
        }
    }

    void EnemyDead()
    {
        Destroy(gameObject);
    }
}
