using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DavidManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Adjust audio sources
        AudioManager.Instance.SourceBGM.clip = AudioManager.Instance.DavidBGM;
        AudioManager.Instance.SourceBGM.Play();

        AudioManager.Instance.SourceBGM.volume = 0.05f;
        AudioManager.Instance.SourceSFX.volume = 0.12f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
