using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    [SerializeField] public bool isToggleAble = true;

    [SerializeField] public bool isActive = false;

    [SerializeField] private AudioClip PressSound;

    [SerializeField] private Color NormalColor = Color.white;
    [SerializeField] private Color ActivatedColor;

    [SerializeField] private GameObject[] ObjectsToToggle;

    private bool isToggling = false;
    private bool wasToggled = false;
    private Vector3 origin;
    
    // Start is called before the first frame update
    void Start()
    {
        if (isActive)
            GetComponent<Renderer>().material.color = ActivatedColor;
        else
            GetComponent<Renderer>().material.color = NormalColor;
        
        origin  = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Switch collided with " + other.name);
        if (other.CompareTag("Player") && !isToggling)
        {
            Debug.Log("Activated Switch " + name);
            StartCoroutine(toggleSwitch());
        }
    }

    IEnumerator toggleSwitch(bool forcetoggle = false, float delay = 0f)
    {
        if (delay != 0f)
            yield return new WaitForSeconds(delay);
        
        //Exit if button should only be pressed once
        if (wasToggled && !isToggleAble && !forcetoggle)
            yield break;
        isActive = !isActive;
        
        isToggling = true;
        if(PressSound != null && !isActive)
            AudioManager.Instance.SourceSFX.PlayOneShot(PressSound, 1f);
        while(Vector3.Distance(new Vector3(origin.x, origin.y - 0.1f, origin.z), transform.position) > 0.02f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(origin.x, origin.y - 0.1f, origin.z), Time.deltaTime);
            yield return null;
        }
        
        if (isActive)
            GetComponent<Renderer>().material.color = ActivatedColor;
        else
            GetComponent<Renderer>().material.color = NormalColor;
        
        while (Vector3.Distance(origin, transform.position) > 0.02f)
        {
            transform.position = Vector3.MoveTowards(transform.position, origin, Time.deltaTime);
            yield return null;
        }

        foreach (GameObject obj in ObjectsToToggle)
        {
            obj.SetActive(!obj.activeSelf);
        }

        wasToggled = !wasToggled;
        isToggling = false;
        
        
        
        yield return null;
    }

    public void reset(float delay = 0f)
    {
        StartCoroutine(resetSwitch(delay));
    }

    IEnumerator resetSwitch(float delay)
    {
        if (delay != 0f)
            yield return new WaitForSeconds(delay);
        Debug.Log("Resetting " + name);
        StartCoroutine(toggleSwitch(true));
    }
}
