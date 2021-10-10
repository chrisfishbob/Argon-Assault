using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectedLevelLoader : MonoBehaviour
{
    public void LoadSelectedLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
