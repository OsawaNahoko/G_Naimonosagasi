using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 origin    = new Vector3(0,0,0);//原点
        Vector3 direction = new Vector3(1,0,0);//方向を表すベクトル
        Ray ray           = new Ray(origin,direction);//Rayを生成

        Debug.DrawRay(ray.origin,ray.direction * 50,Color.red,100.0f);

        // Ray ray = new Ray(Vector3 origin, Vector3 direction);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
