using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowReadjust : MonoBehaviour
{
    public Transform target;
    public float duration = 3f;
    public float Speed = 1f;
    [SerializeField] public bool StartReadjust = false;

    private Vector3 startPosition;
    private float elapsedTime = 0f;

    private bool reachedDestination = false;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if(StartReadjust)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * Speed);

            if (!reachedDestination && Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                reachedDestination = true;
                transform.position = target.position;
            }
        }
    }
}
