using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public float invokeDelayTime = 1f;

    public AudioClip crashAudioClip;
    public AudioClip finsihAudioClip;

    // In order to avoiding all the collision after crash or finish.
    private bool isTransitioning = false;
    private AudioSource m_audioSource;

    void Start() {
        m_audioSource = GetComponent<AudioSource>();   
    }

    private void OnCollisionEnter(Collision other) {
        if (isTransitioning)
            return;
        
        switch (other.gameObject.tag)
        {
            case "Start":
                Debug.Log("Start");
                break;
            case "Finish":
                isTransitioning = true;
                FinishHandler();
                break;
            default:
                isTransitioning = true;
                CrashHandler();
                break;
        }
    }

    private void CrashHandler()
    {
        m_audioSource.Stop();
        m_audioSource.PlayOneShot(crashAudioClip);

        GetComponent<Move>().enabled = false;
        Invoke("ReloadScene", invokeDelayTime);
    }

    private void FinishHandler()
    {
        m_audioSource.Stop();
        m_audioSource.PlayOneShot(finsihAudioClip);

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
