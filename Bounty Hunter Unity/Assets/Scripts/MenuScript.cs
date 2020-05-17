using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject MenuButtons;
    public GameObject Title;
    public GameObject Title2;
    public GameObject MissionSelectButtons;

    public void MissionSelect()
    {
        MenuButtons.SetActive(false);
        Title.SetActive(false);
        Title2.SetActive(true);
        MissionSelectButtons.SetActive(true);
    }
}
