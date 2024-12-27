using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    //Rayの飛ばせる距離
    int distans = 10;

    void Update()
    {
        //作成したRayの中にマウスカーソルの位置情報を代入
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Rayの情報
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit,distans))
        {
            if(hit.collider.tag is "NossingObject" or "GameObject")
            {
                Debug.Log(hit.collider.gameObject.transform.position);
                Debug.Log("Objctに当たった！");
            }
        }
        //Rayの可視化    ↓Rayの原点　↓Rayの方向　　　　　↓Rayの色
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);
    }
}

