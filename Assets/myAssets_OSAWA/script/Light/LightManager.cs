using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    bool isPlaing  = false;//処理中かどうかを判定
    GameObject[] _NossingObj;

    [SerializeField]GameObject MainLight;
    [SerializeField]GameObject HandLight;

    Light MainLightComponet;
    Light HandLightComponet;

    [SerializeField] LightData lightData;//LightData
    [SerializeField] GameObject LookLimit;

    // Start is called before the first frame update
    void Start()
    {
        //Sece上にあるNossingObjectを取得
        _NossingObj = GameObject.FindGameObjectsWithTag("NossingObject");

        //MainLiteとHandLitを取得
        if(MainLight != null && HandLight != null)
        {
                MainLightComponet = MainLight.gameObject.GetComponent<Light>();
                HandLightComponet = HandLight.gameObject.GetComponent<Light>();
        }
        else
        {
            Debug.LogError("MainLightかHandLightがNullです。");
        }

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
        
        float a = 0.0f;

        //ライトが点灯していなかったら
        if(lightData.isLighting == false)
        {
            lightData.isLighting = true;//Litghtが点灯している。
            //HandLightを消灯。
            HandLightComponet.intensity = 0.0f;

            //MainLightを徐々に点灯。
            while(MainLightComponet.intensity < 30.0f)
            {
                MainLightComponet.intensity += 5.0f;
                yield return new WaitForSeconds(0.1f);
            }

            LookLimit.SetActive(false);

            //Nossingオブジェクトを表示しています。
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
            
            Debug.Log("ライトアップ！！");
        }
        //ライトが点灯していたら
        else if (lightData.isLighting == true)
        {
            lightData.isLighting = false;//Litghtが消灯している。

            //HandLightを点灯。
            HandLightComponet.intensity = 300.0f;

            // //MainLightを消灯。
            // MainLightComponet.intensity = 0.0f;

            //MainLightを徐々に消灯。
            while(MainLightComponet.intensity > 0.0f)
            {
                MainLightComponet.intensity -= 5.0f;
                yield return new WaitForSeconds(0.1f);
            }

            LookLimit.SetActive(true);

            //Nossingオブジェクトを非表示にしています。
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

            Debug.Log("ライト消灯！！");
        }
        
        yield return new WaitForSeconds(2.0f);

        isPlaing   = false;//判定を元の状態にする。
        Debug.Log($"isPlaing is {isPlaing}");

    }
}
