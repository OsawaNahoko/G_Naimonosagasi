using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look : MonoBehaviour
{
    private float xRot;
    private float yRot;
    public  float MoveSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        xRot += x  * MoveSpeed;
        yRot += -y * MoveSpeed;
        
        transform.rotation = Quaternion.Euler(yRot,xRot,0f);
        
    }
}
