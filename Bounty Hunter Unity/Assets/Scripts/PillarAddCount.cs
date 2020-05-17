using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarAddCount : MonoBehaviour
{
    public float addPillarCount = 1;

    public GameObject Pillars;
    public GameObject PillarScript;

    void Start()
    {
        this.Pillars = GameObject.FindWithTag("Pillars").gameObject;
        this.PillarScript = GameObject.FindWithTag("PillarScript").gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pillars"))
        {
            other.gameObject.SetActive(false);
            DestroyPillars pillarCountScript = PillarScript.GetComponent<DestroyPillars>();
            pillarCountScript.AddPillarCount(addPillarCount);
        }
    }
}
