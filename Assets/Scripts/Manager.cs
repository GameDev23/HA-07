using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public List<GameObject> Collectibles = new List<GameObject>();
    public TextMeshProUGUI TimeTextMesh;
    public TextMeshProUGUI RecordTextMesh;
    public TextMeshProUGUI CollectibleTextMesh;

    public Texture[] Skins;

    public bool isGoal = false;
    public bool isToggled = false;
    private bool hasPrevRecord = false;
    private int sec = 0;
    private float ms = 0;

    private int recordSec = 0;
    private float recordMs = 0f;
    
    public int CoinsLeft;
    public int MaxCoins = 0;
    
    void Awake(){
        if(Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        isGoal = false;
        recordSec = PlayerPrefs.GetInt("DavidSeconds", 0);
        recordMs = PlayerPrefs.GetFloat("DavidMilliseconds", 0f);

        if (recordSec == 0 && recordMs == 0)
        {
            hasPrevRecord = false;
        }
        else
        {
            hasPrevRecord = true;
        }

        if (hasPrevRecord)
            RecordTextMesh.text = "Record: " + recordSec + "s " + recordMs.ToString("0") + "ms";
        CoinsLeft = Collectibles.Count;
        MaxCoins = CoinsLeft;

        CollectibleTextMesh.text = (MaxCoins - CoinsLeft) + " / " + MaxCoins;
        if (CoinsLeft == 0)
        {
            CollectibleTextMesh.text = "<color=green>" + CollectibleTextMesh.text + "</color>";
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (CoinsLeft != Collectibles.Count)
        {
            CoinsLeft = Collectibles.Count;
            CollectibleTextMesh.text = (MaxCoins - CoinsLeft) + " / " + MaxCoins;
            if (CoinsLeft == 0)
            {
                CollectibleTextMesh.text = "<color=green>" + CollectibleTextMesh.text + "</color>";
            }
        }

        if (!isGoal)
        {
            ms += Time.deltaTime * 1000;
            if ((int) ms >= 1000)
            {
                sec += (int) ms / 1000;
                ms %= 1000;
            }

            TimeTextMesh.text = sec + " s";
            if(!hasPrevRecord)
                RecordTextMesh.text ="Record: " + sec + " s";
        }
        else if(!isToggled)
        {
            if((recordSec > sec) || (recordSec == sec && recordMs > ms))
            {
                //Adjust record
                PlayerPrefs.SetInt("DavidSeconds", sec);
                PlayerPrefs.SetFloat("DavidMilliseconds", ms);
                RecordTextMesh.text =  "<color=green>" + TimeTextMesh.text + " " + ms.ToString("0") + " ms" + "</color>";
            }
            TimeTextMesh.text = "<color=green>" + TimeTextMesh.text + " " + ms.ToString("0") + " ms" + "</color>";
            if(!hasPrevRecord)
                RecordTextMesh.text =  "<color=green>" + TimeTextMesh.text + " " + ms.ToString("0") + " ms" + "</color>";
            isToggled = true;
        }
        
    }

    public void Goal()
    {

        SceneManager.LoadScene("Menu");
    }
    
    public IEnumerator Finish(AudioClip clip, float delay)
    {
        
        Manager.Instance.isGoal = true;
        AudioManager.Instance.SourceSFX.PlayOneShot(clip);

        yield return new WaitForSeconds(delay);
        Manager.Instance.Goal();
    }
}
