using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //Debug use
    public float xValue = 0f;


    public float yBoostValue = 0.1f;
    public float yReduceValue = 0.005f;
    
    public float speed = 4f;
    private float yValue = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xValue = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            yValue += yBoostValue;
        }else
        {
            if (yValue > 0)
                yValue -= yReduceValue;
        }
            

        transform.Translate(xValue, yValue, 0);
    }
}
