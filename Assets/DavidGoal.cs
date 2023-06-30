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
            StartCoroutine(Finish());
        }
    }

    IEnumerator Finish()
    {
        wasToggled = true;
        AudioManager.Instance.SourceSFX.PlayOneShot(AudioManager.Instance.Goal,1f);
        foreach (GameObject obj in ParticleSystems)
        {
            obj.SetActive(true);
        }

        yield return new WaitForSeconds(5f);
        Manager.Instance.Goal();
    }
}
