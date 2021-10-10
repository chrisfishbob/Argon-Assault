using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ProcessLoadingLevelOne();
    }

    public void ProcessLoadingLevelOne()
    {
        Invoke("LoadFirstLevel", 0.8f);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(5);
    }
}
