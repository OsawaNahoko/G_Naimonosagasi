using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManeger : MonoBehaviour
{
    public CharacterController charaCon;

    private Vector3 moveInput;
    public float _Speed;//Playreの移動速度
    public float mouseSensitivity;
    

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal") * _Speed * Time.deltaTime;
        moveInput.z = Input.GetAxis("Vertical") * _Speed * Time.deltaTime;

        charaCon.Move(moveInput);
    }

}
