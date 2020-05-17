using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBulletDamage : MonoBehaviour
{
    public float damageEnemy = 34;

    //private void OnCollisionEnter(Collision other)
    //{
        //if (LayerMask.LayerToName(other.collider.gameObject.layer) == "Enemy")
        //{
            //EnemyHealth enemyHealthScript = other.collider.GetComponent<EnemyHealth>();
            //enemyHealthScript.DeductHealth(damageEnemy);
        //}
    //}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealthScript = other.GetComponent<Collider>().GetComponent<EnemyHealth>();
            enemyHealthScript.DeductHealth(damageEnemy);
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            BossHealth bossHealthScript = other.GetComponent<Collider>().GetComponent<BossHealth>();
            bossHealthScript.DeductHealth(damageEnemy);
        }
    }
}
