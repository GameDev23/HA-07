using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiddadleWizard : MonoBehaviour
{
    [SerializeField] private List<GameObject> Objects;

    [SerializeField] private AudioSource audioSource;


    private bool isToggled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isToggled)
        {
            if (audioSource.isPlaying)
            {
                foreach (GameObject obj in Objects)
                {
            
                    obj.transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);

                }
            }
            else
            {
                foreach (GameObject obj in Objects)
                {
                    Destroy(obj);
                }

                isToggled = true;
                StartCoroutine(Die());
            }
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(2f);
        AudioManager.Instance.SourceSFX.PlayOneShot(AudioManager.Instance.FartReverb, 2f);
        Destroy(gameObject);
    }
}
