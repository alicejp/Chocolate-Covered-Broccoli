using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //Debug use
    public Vector3 zValue;
    public float yBoostValue = 0.1f;
    public float rotateValue = 4f;

    public ParticleSystem boostParticle;
    public ParticleSystem leftTrustParticle;
    public ParticleSystem rightTrushParticle;

    private Rigidbody m_rigidbody;
    private AudioSource m_audioSource;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        processBoost();
        processRotation();
    }

    void processBoost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            m_rigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * yBoostValue);
            if (!m_audioSource.isPlaying)
                m_audioSource.Play();
            
            if(!boostParticle.isPlaying)
                boostParticle.Play();
        }
        else
        {
            m_audioSource.Stop();
            boostParticle.Stop();
        }
    }

    void processRotation()
    {
        zValue = Vector3.forward * Time.deltaTime * rotateValue;

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-zValue);
            if(!rightTrushParticle.isPlaying)
                rightTrushParticle.Play();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(zValue);
            if(!leftTrustParticle.isPlaying)
                leftTrustParticle.Play();
        }
        else
        {
            rightTrushParticle.Stop();
            leftTrustParticle.Stop();
        }
    }
}
