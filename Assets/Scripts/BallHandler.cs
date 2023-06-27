using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    [SerializeField] Camera Cam;
    [SerializeField] float Accelerationes = 1;
    //This script handles the Ball ( ͡° ͜ʖ ͡°)   e.g the Movement etc

    private Rigidbody rg;
    // Start is called before the first frame update
    void Start()
    {
        Cam.transform.position = new Vector3(0,Cam.transform.position.y + 10,0);
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Debug.Log("Adding force");
            rg.AddForce(Vector3.right * Input.GetAxis("Horizontal")*Accelerationes);
        }
        if (Input.GetButton("Vertical"))
        {
            Debug.Log("Adding force");
            rg.AddForce(Vector3.forward * Input.GetAxis("Vertical")*Accelerationes);
        }

        Vector3 temp = transform.position;
        Cam.transform.position = new Vector3(temp.x, Cam.transform.position.y, temp.z-30);
    }
}
