using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource SourceBGM;
    public AudioSource SourceSFX;
    public AudioClip DavidBGM;
    public AudioClip Qua;
    public AudioClip Son;
    public AudioClip VineBoom;
    public AudioClip SonicCoin;
    public AudioClip WindyCreepy;
    public AudioClip SwitchFlick;
    void Awake(){
        if(Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
