using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSetActiveSwitier : MonoBehaviour
{
    [SerializeField] bool SetActive_falseFlag;
    [SerializeField] bool SetActive_trueFlag;

    [SerializeField] float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        if(SetActive_falseFlag == true)
        {
           StartCoroutine(SetActive_false(waitTime));
        }

        if(SetActive_trueFlag == true)
        {
           StartCoroutine(SetActive_true(waitTime));
        }
    }

     IEnumerator SetActive_false(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        this.gameObject.SetActive (false);
    }
    IEnumerator SetActive_true(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        this.gameObject.SetActive (false);
    }

}
