using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag)
        {
            case "Finish":
                Debug.Log("Finish");
                break;
            
            default:
                Debug.Log("default");
                break;
        }
    }
}
