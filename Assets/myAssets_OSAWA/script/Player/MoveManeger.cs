using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManeger : MonoBehaviour
{
    [SerializeField]CharacterController charaCon;

    [SerializeField] float _Speed;           //Playreの移動速度
    [SerializeField] float _mouseSensitivity;//Mousecasollの移動速度
    
    [SerializeField] Transform camTrans;

    
    Vector3 moveInput;
        
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector3 verMove = transform.forward * Input.GetAxis("Vertical");
        Vector3 horiMove = transform.right *Input.GetAxis("Horizontal");

        moveInput = horiMove + verMove;
        moveInput.Normalize();
        moveInput = moveInput * _Speed;

        charaCon.Move(moveInput*Time.deltaTime);
        
        //カメラの回転制御
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * _mouseSensitivity;
        
        transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
        camTrans.rotation = Quaternion.Euler(camTrans.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));
    }

}
