using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelTwoLoader : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadSecondLevel", 0.8f);
    }


    public void LoadSecondLevel()
    {
        SceneManager.LoadScene(6);
    }
}

