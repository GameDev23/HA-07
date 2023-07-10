using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDavidLevelClick()
    {
        SceneManager.LoadScene("DavidLevel");
    }

    public void OnMarvinLevelClick()
    {
        SceneManager.LoadScene("Marvin Level");
    }

    public void OnSamwelLevelClick()
    {
        SceneManager.LoadScene("SamwelLevel");
    }

    public void OnSprite1Click()
    {
        PlayerPrefs.SetInt("Skin", 0);
    }
    
    public void OnSprite2Click()
    {
        PlayerPrefs.SetInt("Skin", 1);
    }
    
    public void OnSprite3Click()
    {
        PlayerPrefs.SetInt("Skin", 2);
    }
}
