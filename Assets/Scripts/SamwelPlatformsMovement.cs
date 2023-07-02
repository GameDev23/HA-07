using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamwelPlatformsMovement : MonoBehaviour
{

    [SerializeField] Vector3 MovingVector;
    [SerializeField] float MovingTime;
    public bool hasStarted = false;
    private float elapsedTime = 0f;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        if (!hasStarted)
        {
            elapsedTime = MovingTime / 2; // when we start we are in the middle
            hasStarted = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
         transform.position += MovingVector * Time.deltaTime;
         elapsedTime += Time.deltaTime;

        if (Player != null) 
        {
            Player.transform.position += MovingVector * Time.deltaTime;
        }

        if (elapsedTime >= MovingTime)
        {
            elapsedTime = 0f;
            MovingVector *= -1;
        }
    }

    /// <summary>
    /// Controls the movement of the player with the platform
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player = collision.gameObject;

        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player = null;

        }
    }
}
