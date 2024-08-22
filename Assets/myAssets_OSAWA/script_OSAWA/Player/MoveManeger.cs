using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManeger : MonoBehaviour
{
    public float MoveSpeed; 

    void Update()
    {
        if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
        {
            forwardMove();
            Debug.Log("Wおされてんぞ");
        }

        if(Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow))
        {
            BackMove();
            Debug.Log("Sおされてんぞ");
        }
    }
     void forwardMove()
     {
        this.transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        // this.transform.Translate(0.0f,0.0f, MoveSpeed);
     }

     void BackMove()
     {
        this.transform.position += transform.forward * - MoveSpeed * Time.deltaTime;
        //this.transform.Translate(0.0f,0.0f, - MoveSpeed);
     }
}
