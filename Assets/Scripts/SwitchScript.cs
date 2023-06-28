using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    [SerializeField] private bool isToggleAble = true;

    [SerializeField] private bool isActive = false;

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
            GetComponent<Renderer>().material.color = Color.white;
        
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
    
    IEnumerator toggleSwitch()
    {
        //Exit if button should only be pressed once
        if (wasToggled && !isToggleAble)
            yield break;
        isActive = !isActive;
        
        isToggling = true;
        while(Vector3.Distance(new Vector3(origin.x, origin.y - 0.1f, origin.z), transform.position) > 0.02f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(origin.x, origin.y - 0.1f, origin.z), Time.deltaTime);
            yield return null;
        }
        
        if (isActive)
            GetComponent<Renderer>().material.color = ActivatedColor;
        else
            GetComponent<Renderer>().material.color = Color.white;
        
        while (Vector3.Distance(origin, transform.position) > 0.02f)
        {
            transform.position = Vector3.MoveTowards(transform.position, origin, Time.deltaTime);
            yield return null;
        }

        foreach (GameObject obj in ObjectsToToggle)
        {
            obj.SetActive(!obj.activeSelf);
        }
        
        isToggling = false;
        
        
        
        yield return null;
    }
}
