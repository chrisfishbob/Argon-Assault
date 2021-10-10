using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollissionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;

    void OnTriggerEnter(Collider colliderInfo)
    {
        if(colliderInfo.gameObject.tag == "Untagged")
        {
            StartDeathSequence();
        }

        if(colliderInfo.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }



    private void StartDeathSequence()
    {
        Invoke("ReloadScene", 2f);
        SendMessage("OnPlayerDeath");

    }

    private void ReloadScene() //string referenced
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
