using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mission1Start : MonoBehaviour
{
    public GameObject Canvas;



    public void Mission1()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
        Canvas.GetComponent<ESCPauseMenu>().Resume();
    }
}
