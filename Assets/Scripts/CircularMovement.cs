using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    [SerializeField] public float radius = 2f;
    [SerializeField] public float speed = 2f;
    [SerializeField] public bool StartCircularMovement = false;

    private float angle = 0f;
    private Vector3 centerPoint;
    private Vector3 copyCenterPoint;

    private void Start()
    {
        centerPoint = transform.position;
        copyCenterPoint = transform.position;
    }

    private void Update()
    {
        if (StartCircularMovement)
        {
            angle += speed * Time.deltaTime;
            float x = centerPoint.x + radius * Mathf.Cos(angle);
            float y = centerPoint.y + radius * Mathf.Sin(angle);
            float z = centerPoint.z;

            transform.position = new Vector3(x, y, z);
        }

        else 
        {
            transform.position = copyCenterPoint;
        }
    }
}
