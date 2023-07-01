using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DavidGoal : MonoBehaviour
{
    [SerializeField] GameObject[] ParticleSystems;

    private bool wasToggled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !wasToggled)
        {
            if(Manager.Instance.CoinsLeft != 0)
                return;
            StartCoroutine(Manager.Instance.Finish(AudioManager.Instance.Goal, 5f));
            if (Manager.Instance.isGoal)
            {
                wasToggled = true;
                foreach (GameObject obj in ParticleSystems)
                {
                    obj.SetActive(true);
                }
            }
        }
    }
    
}
