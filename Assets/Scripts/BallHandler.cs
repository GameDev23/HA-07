using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    //This script handles the Ball ( ͡° ͜ʖ ͡°)   e.g the Movement etc

    [SerializeField] private float Acceleration = 1f;
    [SerializeField] private Vector3 MaxVelocity = new Vector3(8f, 100f, 8f);
    [SerializeField] private Camera camera;
    [SerializeField] private float OffsetFromPlayer = 5;
    [SerializeField] private float JumpStrength = 5;

    public bool isOnGround = true;
    public int MidAirJumps = 1;
    
    private Rigidbody rg;

    private int jumpsLeft = 0;
    private Vector3 MoveVector = new Vector3(0, 0, 0);
    
    
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        camera.transform.position =
            new Vector3(transform.position.x, camera.transform.position.y, transform.position.z - OffsetFromPlayer);

        jumpsLeft = MidAirJumps;
    }

    //Using fixed Update for physics manipulation to make it framerate independent
    private void FixedUpdate()
    {
        if (MoveVector.magnitude > 0)
        {
            
            //dont let the ball surpass the max velocity
            if (Math.Abs(rg.velocity.x) > MaxVelocity.x)
                MoveVector.x = 0;
            if (Math.Abs(rg.velocity.y) > MaxVelocity.y)
                MoveVector.y = 0;
            if (Math.Abs(rg.velocity.z) > MaxVelocity.z)
                MoveVector.z = 0;
            rg.AddForce(MoveVector);
        }
        else
        {
            // No input was given, so we slow the ball gradually
            rg.AddForce(Vector3.Lerp(-rg.velocity, Vector3.zero, Time.deltaTime));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        //get the Input of the Ball
        MoveVector = new Vector3();
        if (Input.GetButton("Horizontal"))
        {
            MoveVector += MoveVector + Vector3.right * Input.GetAxis("Horizontal") * Acceleration;

        }
        if (Input.GetButton("Vertical"))
        {
            MoveVector += MoveVector + Vector3.forward * Input.GetAxis("Vertical") * Acceleration;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        
        //Adjust camera to follow player
        camera.transform.position =
            new Vector3(transform.position.x, camera.transform.position.y, transform.position.z - OffsetFromPlayer);
    }

    private void Jump()
    {
        //handle jump
        if (isOnGround || jumpsLeft > 0)
        {
            rg.AddForce(Vector3.up * JumpStrength);
            //decrease jumps if not on ground
            if(!isOnGround)
                jumpsLeft = jumpsLeft > 0 ? jumpsLeft - 1 : 0;
            
            
            isOnGround = false;
            
            
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Player collided with " + other.gameObject.name);
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Hit ground. Resetting jumps");
            isOnGround = true;
            jumpsLeft = MidAirJumps;
        }
    }
}
