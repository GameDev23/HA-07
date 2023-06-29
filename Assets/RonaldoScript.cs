using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RonaldoScript : MonoBehaviour
{
    [SerializeField] private float LifeTime = 5f;

    private float elapsedTime = 0f;

    private Vector3 Origin;

    private void Awake()
    {
        Origin = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        transform.position = Origin;
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= LifeTime)
            Destroy(gameObject);
    }
}
