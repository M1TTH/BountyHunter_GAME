using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyPillars : MonoBehaviour
{
    public float pillarcountHealth = 1f;

    public GameObject Shield;

    public void AddPillarCount(float addPillarCount)
    {
        pillarcountHealth += addPillarCount;

        if (pillarcountHealth >= 5)
        {
            Shield.SetActive(false);
        }
    }

}