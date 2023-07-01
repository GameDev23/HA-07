using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    public Transform targetObject;
    public Rigidbody playerRg;
    public float rotationSpeed = 5f;
    private Vector3 prevPosition = new Vector3();
    private ParticleSystem ps;
    private ParticleSystem.MainModule mainModule;
    private ParticleSystem.EmissionModule emissionModule;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        mainModule = ps.main;
        emissionModule = ps.emission;
    }

    private void Update()
    {
        if(BallManager.Instance.isOnGround && (Input.GetButton("Horizontal") || Input.GetButton("Vertical")))
        {
            // Berechne die Richtung vom aktuellen Objekt zum Zielobjekt
            Vector3 direction = targetObject.position - prevPosition;

            // Überprüfe, ob der Richtungsvektor nicht Null ist
            if (direction != Vector3.zero)
            {
                direction = -direction;
                // Drehe das Objekt in Richtung des Ziels
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            }

            if (playerRg.velocity.magnitude > 0.3f)
            {
                emissionModule.enabled = true;
                mainModule.startSpeed = playerRg.velocity.magnitude;
            }
            else
            {
                emissionModule.enabled = false;
            }
        }
        else
        {
            emissionModule.enabled = false;
        }


        prevPosition = targetObject.position;
    }
}
