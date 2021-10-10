using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelThreeLoader : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadThirdLevel", 0.8f);
    }


    public void LoadThirdLevel()
    {
        SceneManager.LoadScene(7);
    }
}
