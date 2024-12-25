using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : MonoBehaviour
{
    bool isPlaing  = false;//処理中かどうかを判定
    bool isLighting= false;//GlobalLightが９０度回転しているかどうかを判定

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && isPlaing == false)
        {

            StartCoroutine("Light_Up");
        }
        
    }

    IEnumerator Light_Up()
    {
        isPlaing   = true;//判定を処理中にする。

        //ライトが点灯していなかったら
        if(isLighting == false)
        {
            isLighting = true;//Litghtが点灯している。
            //LItghtを点灯させます。
            //Litghtの角度90度に。
            Debug.Log("ライトアップ！！ほら見て豪蘭さんきれいだよ。");
        }
        //ライトが点灯していたら
        else if (isLighting == true)
        {
            isLighting = false;//Litghtが消灯している。
            //LItghtを消灯させます。
            //Litghtの角度160度に。
            Debug.Log("ライト消灯！！！寝な。");
        }
        yield return new WaitForSeconds(5.0f);

        isPlaing   = false;//判定を元の状態にする。
        Debug.Log($"isPlaing is {isPlaing}");

    }
}
