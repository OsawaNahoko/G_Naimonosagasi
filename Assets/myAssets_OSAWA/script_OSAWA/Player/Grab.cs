using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    //Rayの飛ばせる距離
    [SerializeField] int distans = 10;
    [SerializeField] Transform grabPoint;
    
    GameObject GrabObj;
    bool _GrabFlag = false;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            RayCast_Object();

            if(GrabObj != null)
            {
                //オブジェクトの取得処理
                if(_GrabFlag == false)
                {
                    GrabObj.GetComponent<Rigidbody>().isKinematic = true;
                    GrabObj.transform.position = grabPoint.position;
                    GrabObj.transform.SetParent(transform);

                    _GrabFlag = true;
                }
                else
                {
                    GrabObj.GetComponent<Rigidbody>().isKinematic = false;
                    GrabObj.transform.SetParent(null);
                    GrabObj = null;

                    _GrabFlag = false;
                }
            }
            else if(GrabObj == null)
            {
                Debug.Log("GrabObj is Null");
            }



            Debug.Log("左クリックを検知");
        }
    }

    void RayCast_Object()
    {
            //レイを作成
            //作成したRayの中にマウスカーソルの位置情報を代入
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Rayの情報
            RaycastHit hit;
            //Rayがオブジェクトに衝突した際の処理
            if (Physics.Raycast(ray,out hit,distans))
            {
                if(hit.collider.tag is "NossingObject" or "GameObject")
                {
                    GrabObj = hit.collider.gameObject;
                    Debug.Log(hit.collider.gameObject.transform.position);
                    Debug.Log("Objctに当たった！");
                }
            }
            //Rayの可視化    ↓Rayの原点　↓Rayの方向　　　　　↓Rayの色
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);
    }
}
