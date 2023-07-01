using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WDDD : MonoBehaviour
{
    [SerializeField] private List<GameObject> CorrectOrder = new List<GameObject>();
    [SerializeField] private TextMeshPro textMesh;
    [SerializeField] private GameObject[] ToEnable;

    public static WDDD Instance;
    public bool signal = false;

    private SwitchScript button1;
    private SwitchScript button2;
    private SwitchScript button3;
    private SwitchScript button4;

    private bool prevButton1 = false;
    private bool prevButton2 = false;
    private bool prevButton3 = false;
    private bool prevButton4 = false;

    private string correctSequence = "what the dog doin ";
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
        button4 = CorrectOrder[3].GetComponent<SwitchScript>();

        textMesh.text = "Solve the Riddle so you may skididle";
    }

    // Update is called once per frame
    void Update()
    {
        if (!signal)
        {
            if (prevButton1 != button1.isActive || prevButton2 != button2.isActive || prevButton3 != button3.isActive || prevButton4 != button4.isActive)
            {
                if (prevButton1 != button1.isActive)
                {
                    if (!currentSequence.Contains("what "))
                    {
                        currentSequence += "what ";
                    }
                    prevButton1 = button1.isActive;
                }
                if (prevButton2 != button2.isActive)
                {
                    if (!currentSequence.Contains("the "))
                    {
                        currentSequence += "the ";
                    }
                    prevButton2 = button2.isActive;
                }
                if (prevButton3 != button3.isActive)
                {
                    if (!currentSequence.Contains("dog "))
                    {
                        currentSequence += "dog ";
                    }
                    prevButton3 = button3.isActive;
                }
                if (prevButton4 != button4.isActive)
                {
                    if (!currentSequence.Contains("doin "))
                    {
                        currentSequence += "doin ";
                    }
                    prevButton4 = button4.isActive;
                }

                textMesh.text = currentSequence;
                CheckCombination();
            }
        }
 
        //Debug.Log(currentSequence);
    }

    void CheckCombination()
    {
        if (prevButton1 && prevButton2 && prevButton3 && prevButton4)
        {
            Debug.Log(currentSequence);
            //do check here
            if (currentSequence == correctSequence)
            {
                //input was correct
                StartCoroutine(PlaySound(AudioManager.Instance.WhatTheDogDoin, 0.5f));
            }
            else
            {
                StartCoroutine(PlaySound(AudioManager.Instance.FartReverb, 1f));
                currentSequence = "";

                StartCoroutine(WaitForReset());
                button1.reset(1);
                button2.reset(1);
                button3.reset(1);
                button4.reset(1);
                prevButton1 = false;
                prevButton2 = false;
                prevButton3 = false;
                prevButton4 = false;
            }

        }
        
    }

    IEnumerator PlaySound(AudioClip clip, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (currentSequence == correctSequence)
        {
            // has won
            textMesh.text = "You are allowed to continue your journey";
            yield return new WaitForSeconds(2f);
            foreach (GameObject obj in ToEnable)
            {
                obj.SetActive(!obj.activeSelf);
            }
        }
        else
        {
            // incorrect
            textMesh.text = "Ayo, come on. Try again";
        }
        AudioManager.Instance.SourceSFX.PlayOneShot(clip);
    }

    IEnumerator WaitForReset()
    {
        signal = true;
        //wait for the buttons to toggle back to not active
        while (button1.isActive || button2.isActive || button3.isActive || button4.isActive)
        {
            yield return null;
        }

        signal = false;
    }
    
    
}
