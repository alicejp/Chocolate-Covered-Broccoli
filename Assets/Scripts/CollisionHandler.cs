using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag)
        {
            case "Start":
                Debug.Log("Start");
                break;
            case "Finish":
                LoadNextScene();
                break;
            default:
                ReloadScene();
                break;
        }
    }

    private void LoadNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index == SceneManager.sceneCountInBuildSettings-1)
        {
            Debug.Log("Last scene, you won !! Congrats");
        }
        else
        {
            SceneManager.LoadScene(index+1);
            Debug.Log("Load Next Scene");
        }
        
    }

    private void ReloadScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
        Debug.Log("Restart");
    }
}
