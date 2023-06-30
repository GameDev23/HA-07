using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineBoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        AudioManager.Instance.SourceSFX.PlayOneShot(AudioManager.Instance.VineBoom, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
