using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public float invokeDelayTime = 1f;

    private void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag)
        {
            case "Start":
                Debug.Log("Start");
                break;
            case "Finish":
                FinishHandler();
                break;
            default:
                CrashHandler();
                break;
        }
    }

    private void CrashHandler()
    {
        GetComponent<Move>().enabled = false;
        Invoke("ReloadScene", invokeDelayTime);
    }

    private void FinishHandler()
    {
        GetComponent<Move>().enabled = false;
        Invoke("LoadNextScene", invokeDelayTime);
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
