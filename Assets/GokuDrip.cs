using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GokuDrip : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    [SerializeField] private float DestroyAfterSeconds = 12f;
    [SerializeField] private GameObject[] ActivateBeforeDestroy;
    private float clipLength;
    private bool hasFinished = false;

    private float elapsedTime = 0f;
    
    private Rigidbody rg;

    private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        
        rg = GetComponent<Rigidbody>();
        
        AudioManager.Instance.SourceSFX.PlayOneShot(AudioManager.Instance.GokuDrip,1f);
        clipLength = AudioManager.Instance.GokuDrip.length;
        targetPos = Target.transform.position;

        rg.AddForce(Vector3.up);

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        DestroyAfterSeconds -= Time.deltaTime;
            

        if (elapsedTime + 0.1f > clipLength && !hasFinished)
        {
            elapsedTime = 0f;
            AudioManager.Instance.SourceSFX.PlayOneShot(AudioManager.Instance.GokuDrip,1f);
        }

        if (Vector3.Distance(transform.position, targetPos) < 0.01)
        {
            rg.AddForce(Vector3.down);
        }
        else
        {
            transform.position += Vector3.up * Time.deltaTime;
        }

        if (!hasFinished)
        {
            if (DestroyAfterSeconds <= 0)
            {
                foreach (GameObject obj in ActivateBeforeDestroy)
                {
                    obj.SetActive(!obj.activeSelf);
                }

                hasFinished = true;
            }
            
        }
        
    }



    private void OnEnable()
    {
        
    }
}
