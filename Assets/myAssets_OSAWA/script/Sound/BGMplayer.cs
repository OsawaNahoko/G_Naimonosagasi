using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMplayer : MonoBehaviour
{
    [SerializeField] bool IsFade;
    [SerializeField] float FadeInSeconds = 1.0f;

    bool IsFadeIn = true;
    float FadeDeltaTime = 0.0f;
    
    AudioSource audioSource;
 
    void Start()
    {
        audioSource =  this.gameObject.GetComponent<AudioSource>();
    }
 
    void FadeBGM()
    {
         if (IsFadeIn)
        {
             FadeDeltaTime += Time.deltaTime;
             if (FadeDeltaTime >= FadeInSeconds)
            {
                FadeDeltaTime = FadeInSeconds;
                IsFadeIn = false;
            }
            audioSource.volume = FadeDeltaTime / FadeInSeconds;
        }
    } 
}
