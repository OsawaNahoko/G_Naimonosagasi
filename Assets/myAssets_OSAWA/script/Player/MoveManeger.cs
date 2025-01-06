using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController charaCon;
    Vector3 moveVelocity;  // キャラクターコントローラーを動かすためのVector3型の変数

    [SerializeField] float _Speed;           //Playreの移動速度
    [SerializeField] float _mouseSensitivity;//Mousecasollの移動速度
    [SerializeField] float _ContrerSenstivity;//コントローラーの移動速度

    
    [SerializeField] Transform camTrans;

    Vector3 moveInput;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        charaCon = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 verMove = transform.forward * Input.GetAxis("Vertical");
        Vector3 horiMove = transform.right *Input.GetAxis("Horizontal");

        moveInput = horiMove + verMove;
        moveInput.Normalize();
        moveInput = moveInput * _Speed;

        charaCon.Move(moveInput*Time.deltaTime);
        
        //カメラの回転制御　マウス;
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * _mouseSensitivity;
        
        transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
        camTrans.rotation = Quaternion.Euler(camTrans.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));
        
        //カメラの回転制御　コントローラー;
        Vector2 ContlerInput = new Vector2(Input.GetAxisRaw("Vertical2"), Input.GetAxisRaw("Horizontal2")) * _ContrerSenstivity;
                
        transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y + ContlerInput.x, transform.rotation.eulerAngles.z);
        camTrans.rotation = Quaternion.Euler(camTrans.rotation.eulerAngles + new Vector3(-ContlerInput.y, 0f, 0f));


        if(Input.GetAxis("Vertical") >= 1)
        Debug.Log("Vertical2反応しています");
        
        if(Input.GetAxis("Horizontal") >= 1)
        Debug.Log("Vertical2反応しています");

        // 接地しているとき
        if(charaCon.isGrounded)
        {

        }
        // 空中にいる時
        else
        {
            // 重力をかける
            moveVelocity.y += Physics.gravity.y * Time.deltaTime;
        }

        // キャラクターを動かす
        charaCon.Move(moveVelocity * Time.deltaTime);
    }
}
