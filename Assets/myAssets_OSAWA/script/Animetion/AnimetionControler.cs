using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimetionControler : MonoBehaviour
{
    [SerializeField] Animator[]   AnimatorArray;
    // [SerializeField] string[]     TriggerArray;
    [SerializeField] string[]     FlagArray;

    protected void PlayBoolAnime(int PlayNumber)
    {
        for (int i = 0; i < AnimatorArray.Length; i++)
        {
            AnimatorArray[i].SetBool(FlagArray[PlayNumber],true);
        }
    }

    // protected void PlayTriggerAnime(int PlayNumber)
    // {
    //     for(int i = 0; i < AnimatorArray.Length; i++)
    //     {
    //         AnimatorArray[i].SetTrigger(TriggerArray[PlayNumber]);
    //     }
    // }

    protected void PlayFadeIN()
    {
        AnimatorArray[2].SetBool(FlagArray[3],true);
        AnimatorArray[2].SetBool(FlagArray[4],false);
    }

    protected void PlayFadeOUT()
    {
        AnimatorArray[2].SetBool(FlagArray[4],true);
        AnimatorArray[2].SetBool(FlagArray[3],false);
    }

}
   
