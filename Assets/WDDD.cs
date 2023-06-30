using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WDDD : MonoBehaviour
{
    [SerializeField] private List<GameObject> CorrectOrder = new List<GameObject>();

    public static WDDD Instance;
    public bool signal = false;

    private SwitchScript button1;
    private SwitchScript button2;
    private SwitchScript button3;

    private bool prevButton1 = false;
    private bool prevButton2 = false;
    private bool prevButton3 = false;

    private string correctSequence = "123";
    private string currentSequence = "";
    
    void Awake(){
        if(Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        button1 = CorrectOrder[0].GetComponent<SwitchScript>();
        button2 = CorrectOrder[1].GetComponent<SwitchScript>();
        button3 = CorrectOrder[2].GetComponent<SwitchScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!signal)
        {
            if (prevButton1 != button1.isActive || prevButton2 != button2.isActive || prevButton3 != button3.isActive)
            {
                if (prevButton1 != button1.isActive)
                {
                    if (!currentSequence.Contains("1"))
                    {
                        currentSequence += "1";
                    }
                    prevButton1 = button1.isActive;
                }
                if (prevButton2 != button2.isActive)
                {
                    if (!currentSequence.Contains("2"))
                    {
                        currentSequence += "2";
                    }
                    prevButton2 = button2.isActive;
                }
                if (prevButton3 != button3.isActive)
                {
                    if (!currentSequence.Contains("3"))
                    {
                        currentSequence += "3";
                    }
                    prevButton3 = button3.isActive;
                } 
            
            
                CheckCombination();
            }
        }
 
        //Debug.Log(currentSequence);
    }

    void CheckCombination()
    {
        if (prevButton1 && prevButton2 && prevButton3)
        {
            Debug.Log(currentSequence);
            //do check here
            if (currentSequence == correctSequence)
                StartCoroutine(PlaySound(AudioManager.Instance.WhatTheDogDoin, 0.5f));
            else
            {
                StartCoroutine(PlaySound(AudioManager.Instance.FartReverb, 0.5f));
                currentSequence = "";

                StartCoroutine(WaitForReset());
                button1.reset(1);
                button2.reset(1);
                button3.reset(1);
                prevButton1 = false;
                prevButton2 = false;
                prevButton3 = false;
            }

        }
        
    }

    IEnumerator PlaySound(AudioClip clip, float delay)
    {
        yield return new WaitForSeconds(delay);
        AudioManager.Instance.SourceSFX.PlayOneShot(clip);
    }

    IEnumerator WaitForReset()
    {
        signal = true;
        //wait for the buttons to toggle back to not active
        while (button1.isActive || button2.isActive || button3.isActive)
        {
            yield return null;
        }

        signal = false;
    }
    
    
}
