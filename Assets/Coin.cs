using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject ParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collected Coin");
            GameObject ps = Instantiate(ParticleSystem);
            ps.transform.position = transform.position;
        
            AudioManager.Instance.SourceSFX.PlayOneShot(AudioManager.Instance.SonicCoin, 0.5f);
            Destroy(gameObject);
        }
    }
}
