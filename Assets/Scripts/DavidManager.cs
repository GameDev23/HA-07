using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DavidManager : MonoBehaviour
{

    public static DavidManager Instance;
    public int CollectedCoins = 0;
    
    void Awake(){
        if(Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this);
    }
    
    void Start()
    {
        //Adjust audio sources
        AudioManager.Instance.SourceBGM.clip = AudioManager.Instance.DavidBGM;
        AudioManager.Instance.SourceBGM.Play();

        AudioManager.Instance.SourceBGM.volume = 0.05f;
        AudioManager.Instance.SourceSFX.volume = 0.12f;
    }


    void Update()
    {
        
    }
}
