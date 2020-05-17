using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToWeapon1 : MonoBehaviour
{
    public GameObject Rifle;
    public GameObject Pistol;

    void Update()
    {
        if (Input.GetButtonDown("primary"))
        {
            Rifle.SetActive(true);
            Pistol.SetActive(false);
        }
    }
}
