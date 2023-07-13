using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1SwitchEnabler : MonoBehaviour
{
    [SerializeField] private bool isToggleAble = true;

    [SerializeField] private bool isActive = false;

    [SerializeField] private Color NormalColor = Color.white;
    [SerializeField] private Color ActivatedColor;

    [SerializeField] private GameObject[] objectsToEnable;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip PressSound;

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

        origin = transform.position;
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

        if (PressSound != null)
            AudioManager.Instance.SourceSFX.PlayOneShot(PressSound, 1f);

        isToggling = true;
        
        
        if(PressSound != null && isActive)
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
        

        foreach (GameObject obj in objectsToEnable)
        {
            CircularMovement circular = obj.GetComponent<CircularMovement>();
            circular.StartCircularMovement = !circular.StartCircularMovement;

            if (!obj.activeSelf)
            {
                obj.SetActive(true);
            }
        }

        if (isActive)
        {
            audio.Play();
            audio.volume = 0.08f;
        }
        else
        { 
            audio.Pause();
        }

        wasToggled = true;
        isToggling = false;
        yield return null;
    }

}
