using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowReadjust : MonoBehaviour
{
    public Transform target;
    public float duration = 3f;

    private Vector3 startPosition;
    private float elapsedTime = 0f;

    private void Start()
    {
        startPosition = transform.position;
        target.position = new Vector3(11.4f, -1.5f, -54.32846f);
    }

    private void Update()
    {
        /*
        // Check if we've reached the target position
        if (elapsedTime >= duration)
        {
            transform.position = target.position;
            return;
        }

        // Calculate the interpolation factor (0 to 1)
        float t = elapsedTime / duration;

        // Smoothly move the object
        // transform.position = Vector3.Lerp(startPosition, target.position, t);
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime);

        // Increase the elapsed time
        elapsedTime += Time.deltaTime;
        */
    }
}
