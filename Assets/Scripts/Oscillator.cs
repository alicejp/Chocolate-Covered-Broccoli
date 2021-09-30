using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    
    public Vector3 movementVector;
    [Range(-1, 1)] public float movementFactor;
    public float periods = 2f;
    public float timeDelay = 0.1f;

    const float TAU = Mathf.PI * 2;
    private Vector3 offest;
    private Vector3 staringPosition;
    private float cycles;
    

    // Start is called before the first frame update
    void Start()
    {
        staringPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (periods == Mathf.Epsilon)
            return;
        
        cycles = Time.time / periods;

        movementFactor = Mathf.Sin(TAU * cycles + timeDelay);
        offest = movementFactor * movementVector * Time.deltaTime;

        transform.position += offest;
    }
}
