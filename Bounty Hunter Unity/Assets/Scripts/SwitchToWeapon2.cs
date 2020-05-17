using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToWeapon2 : MonoBehaviour
{
    public GameObject Rifle;
    public GameObject Pistol;

    void Update()
    {
        if (Input.GetButtonDown("secondary"))
        {
            Rifle.SetActive(false);
            Pistol.SetActive(true);
        }
    }
}
