using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Text countText;
    public int maxHealth = 100;
    public GameObject oldrifle;
    public GameObject rifle;
    public GameObject pistol;
    public GameObject newrifle;
    public GameObject newpistol;
    public GameObject oldpistol;

    private int count;

    void Start()
    {
        count = 100;
        SetCountText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            count = count - 10;
            SetCountText();
        }
        if (other.gameObject.CompareTag("BossBullet"))
        {
            Destroy(other.gameObject);
            count = count - 20;
            SetCountText();
        }
        if (other.gameObject.CompareTag("UpgradeRifle"))
        {
            Destroy(other.gameObject);
            rifle.SetActive(true);
            oldrifle.SetActive(false);
            newrifle.SetActive(true);
            pistol.SetActive(false);  
        }
        if (other.gameObject.CompareTag("UpgradePistol"))
        {
            Destroy(other.gameObject);
            rifle.SetActive(false);
            oldpistol.SetActive(false);
            newpistol.SetActive(true);
            pistol.SetActive(true);
        }

        if (other.gameObject.CompareTag("HealthPack") && count < maxHealth)
        {
            Destroy(other.gameObject);
            count = count + 20;
            if (count > maxHealth)
            {
                count = maxHealth;
            }
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "HEALTH: " + count.ToString();
        if (count <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}