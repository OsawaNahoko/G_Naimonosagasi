using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    bool isPlaing  = false;//処理中かどうかを判定
    GameObject[] _NossingObj;

    [SerializeField] LightData lightData;//LightData

    // Start is called before the first frame update
    void Start()
    {
        // _NossingObjcount = GameObject.FindGameObjectsWithTag("NossingObj").Length;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && isPlaing == false)
        {
            if(lightData != null)
            {
                StartCoroutine("Light_Up");
            }
            else
            {
                Debug.LogError("lightData is Null");
            }
        }
    }

    IEnumerator Light_Up()
    {
        isPlaing   = true;//判定を処理中にする。

        //ライトが点灯していなかったら
        if(lightData.isLighting == false)
        {
            lightData.isLighting = true;//Litghtが点灯している。
            //LItghtを点灯させます。
            //Litghtの角度90度に。

            _NossingObj = GameObject.FindGameObjectsWithTag("NossingObject");
            if(_NossingObj == null)
            {
                Debug.LogError("Nullだよ");
            }
            else if(_NossingObj != null)
            {
                for(int i = 0; i < _NossingObj.Length; i++)
                {
                    _NossingObj[i].SetActive(true);
                }
            }
            
            Debug.Log("ライトアップ！！ほら見て豪蘭さんきれいだよ。");
        }
        //ライトが点灯していたら
        else if (lightData.isLighting == true)
        {
            lightData.isLighting = false;//Litghtが消灯している。
            //LItghtを消灯させます。
            //Litghtの角度160度に。
            _NossingObj = GameObject.FindGameObjectsWithTag("NossingObject");
            if(_NossingObj == null)
            {
                Debug.LogError("Nullだよ");
            }
            else if(_NossingObj != null)
            {
                for(int i = 0; i < _NossingObj.Length; i++)
                {
                    _NossingObj[i].SetActive(false);
                }
            }

            Debug.Log("ライト消灯！！！寝な。");
        }
        
        yield return new WaitForSeconds(5.0f);

        isPlaing   = false;//判定を元の状態にする。
        Debug.Log($"isPlaing is {isPlaing}");

    }
}
