using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    //Rayの飛ばせる距離
    [SerializeField] int distans = 3;
    [SerializeField] Transform grabPoint;
    
    GameObject GrabObj;
    bool _GrabFlag = false;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire2") )
        {
            
            Debug.Log($"_GrabFlag is {_GrabFlag}");

                //オブジェクトの取得処理
                if(_GrabFlag == false)
                {
                    RayCast_Object();
                    if(GrabObj != null)
                    {
                        GrabObj.GetComponent<Rigidbody>().isKinematic = true;
                        GrabObj.transform.position = grabPoint.position;
                        GrabObj.transform.SetParent(transform);

                        _GrabFlag = true;
                    }
                    else
                    {
                        Debug.Log("GrabObj is Null");
                    }
                }
                else
                {
                    GrabObj.GetComponent<Rigidbody>().isKinematic = false;
                    GrabObj.transform.SetParent(null);
                    GrabObj = null;

                    _GrabFlag = false;
                }

            Debug.Log("左クリックを検知");
        }
    }
    void LookRayCast()
    {
        Ray Lookray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Hitしたオブジェクトの情報
        RaycastHit Lookhit;
        //Rayがオブジェクトに衝突した際の処理
        if (Physics.Raycast(Lookray,out Lookhit,distans) && Lookhit.collider.tag is "NossingObject" or "GameObject")
        {
                GrabObj = Lookhit.collider.gameObject;
                Debug.Log(Lookhit.collider.gameObject.transform.position);
                Debug.Log("Objctに当たった！");
        }
        //Rayの可視化    ↓Rayの原点　↓Rayの方向　　　　　↓Rayの色
        Debug.DrawRay(Lookray.origin, Lookray.direction * 10, Color.red, 5);

    }

    void RayCast_Object()
    {
            //レイを作成
            //作成したRayの中にマウスカーソルの位置情報を代入
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Hitしたオブジェクトの情報
            RaycastHit hit;
            //Rayがオブジェクトに衝突した際の処理
            if (Physics.Raycast(ray,out hit,distans) && hit.collider.tag is "NossingObject" or "GameObject")
            {
                    GrabObj = hit.collider.gameObject;
                    Debug.Log(hit.collider.gameObject.transform.position);
                    Debug.Log("Objctに当たった！");
            }
            //Rayの可視化    ↓Rayの原点　↓Rayの方向　　　　　↓Rayの色
            Debug.DrawRay(ray.origin, ray.direction * distans, Color.red, 5);
    }
}
