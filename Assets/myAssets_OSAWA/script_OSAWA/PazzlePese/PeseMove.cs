using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeseMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos =transform.position;

        pos.x = 0.0f;
        pos.y = 0.0f;
        pos.z = 0.1f;

        transform.position = pos;
        // if(pos.z = 100.0f)
        // {
        //     pos.z = -0.1f;

        // }
        // else if(pos.z = -100.0f)
        // {
        //       pos.z = 0.1f;
        // }

        //  this.transform.position = new Vector3(0.0f,0.0f,0.1f); 
    }
}
