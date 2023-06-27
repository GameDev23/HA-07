using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    //This script handles the Ball ( ͡° ͜ʖ ͡°)   e.g the Movement etc

    private Rigidbody rg;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Debug.Log("Adding force");
            rg.AddForce(Vector3.right * Input.GetAxis("Horizontal"));
        }
        if (Input.GetButton("Vertical"))
        {
            Debug.Log("Adding force");
            rg.AddForce(Vector3.forward * Input.GetAxis("Vertical"));
        }
    }
}
