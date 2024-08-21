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

        if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
           RightMove();
            Debug.Log("Dおされてんぞ");
        }

        if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {
            LeftArrow();
            Debug.Log("Aおされてんぞ");
        }
    }
     void forwardMove()
     {
        this.transform.position += transform.forward * MoveSpeed * Time.deltaTime;
     }

     void BackMove()
     {
        this.transform.position -= transform.forward * MoveSpeed * Time.deltaTime;
     }

     void RightMove()
     {
        this.transform.position  += transform.right * MoveSpeed * Time.deltaTime;
     }

     void LeftArrow()
     {
        this.transform.position  -= transform.right * MoveSpeed * Time.deltaTime;
     }
}
