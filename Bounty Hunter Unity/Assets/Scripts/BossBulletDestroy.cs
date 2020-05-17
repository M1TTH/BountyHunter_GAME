using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletDestroy : MonoBehaviour
{
    public GameObject BossBullet;

    private void OnTriggerEnter(Collider other)
    {
        BossBullet.SetActive(false);
    }
}
