using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{

    public void LoadFirstScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevelOneSplash()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevelTwoSplash()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadLevelThreeSplash()
    {
        SceneManager.LoadScene(4);
    }
}
