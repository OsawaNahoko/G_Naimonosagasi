using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEplayer : AnimetionControler
{
    [SerializeField] AudioClip[] soundArrey;
    [SerializeField] AudioSource SEaudio;

    protected void PlaySound(int Number)
    {
        if(SEaudio == null)
        {
            Debug.Log("audioSourceがnullです。");
        }
        else
        {
            SEaudio.PlayOneShot(soundArrey[Number]);
        }
    }
        

}
