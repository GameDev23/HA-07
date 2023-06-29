using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusMovement : MonoBehaviour
{
    public Vector3 MovementVector;
    public Vector3 TorqueVector;
    private Rigidbody rg;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        rg.AddForce(MovementVector);
        
        rg.AddTorque(TorqueVector, ForceMode.Force);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnEnable()
    {
        
    }
}
