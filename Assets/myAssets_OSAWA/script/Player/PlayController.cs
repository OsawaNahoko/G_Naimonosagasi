using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    CharacterController charaCon;
    Vector3 moveVelocity;  // キャラクターコントローラーを動かすためのVector3型の変数

    [SerializeField] float _Speed;           //Playreの移動速度
    [SerializeField] float _mouseSensitivity;//Mousecasollの移動速度

    
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
        
        //カメラの回転制御
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * _mouseSensitivity;
        
        transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
        camTrans.rotation = Quaternion.Euler(camTrans.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));

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




// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     private CharacterController characterController;  // CharacterController型の変数
//     private Vector3 moveVelocity;  // キャラクターコントローラーを動かすためのVector3型の変数
//     [SerializeField] private Animator animator;
//     [SerializeField] public Transform verRot;  //縦の視点移動の変数(カメラに合わせる)
//     [SerializeField] public Transform horRot;  //横の視点移動の変数(プレイヤーに合わせる)
//     [SerializeField] public float moveSpeed;  //移動速度
//     [SerializeField] public float jumpPower;  //ジャンプ力

//     void Start()
//     {
//         characterController = GetComponent<CharacterController>();
//     }

//     void Update()
//     {
//         // マウスによる視点操作
//         float X_Rotation = Input.GetAxis("Mouse X");
//         float Y_Rotation = Input.GetAxis("Mouse Y");
//         horRot.transform.Rotate(new Vector3(0, X_Rotation * 2, 0));
//         verRot.transform.Rotate(-Y_Rotation * 2, 0, 0);

//         //Wキーがおされたら
//         if(Input.GetKey(KeyCode.W))
//         {
//             characterController.Move(this.gameObject.transform.forward * moveSpeed * Time.deltaTime);
//         }
//         //Sキーがおされたら
//         if (Input.GetKey (KeyCode.S))
// 		{
// 			characterController.Move (this.gameObject.transform.forward * -1f * moveSpeed * Time.deltaTime);
// 		}
// 		//Aキーがおされたら
// 		if (Input.GetKey (KeyCode.A))
// 		{
// 			characterController.Move (this.gameObject.transform.right * -1 * moveSpeed * Time.deltaTime);
// 		}
// 		//Dキーがおされたら
// 		if (Input.GetKey (KeyCode.D))
// 		{
// 			characterController.Move (this.gameObject.transform.right * moveSpeed * Time.deltaTime);
// 		}

//         // 接地しているとき
//         if(characterController.isGrounded)
//         {
//             // ジャンプ
//             if(Input.GetKeyDown(KeyCode.Space))
//             {
//                 moveVelocity.y = jumpPower;
//             }
//         }
//         // 空中にいる時
//         else
//         {
//             // 重力をかける
//             moveVelocity.y += Physics.gravity.y * Time.deltaTime;
//         }

//         // キャラクターを動かす
//         characterController.Move(moveVelocity * Time.deltaTime);

//         // 移動スピードをアニメーターに反映する
//         animator.SetFloat("MoveSpeed", new Vector3(moveVelocity.x, 0, moveVelocity.z).magnitude);
//     }
// }
}
