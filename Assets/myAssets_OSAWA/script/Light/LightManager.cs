using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    bool isPlaing  = false;//処理中かどうかを判定
    [SerializeField]float LightLebel;//ライトの最大値を調整
    float LightCount    = 2.0f;
    float LightWaitTime = 0.01f;
    GameObject[] _NossingObj;

    [SerializeField]GameObject MainLight;
    [SerializeField]GameObject HandLight;

    Light MainLightComponet;
    Light HandLightComponet;

    [SerializeField] LightData lightData;//LightData

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
        if(Input.GetKeyDown(KeyCode.R) && isPlaing == false || Input.GetButtonDown("Fire1") &&  isPlaing == false )
        {
            if(lightData != null)
            {
                StartCoroutine("LightMove");
            }
            else
            {
                Debug.LogError("lightData is Null");
            }
        }
    }

    IEnumerator LightMove()
    {
        isPlaing   = true;//判定を処理中にする。
        
        //ライトが点灯していなかったら
        if(lightData.isLighting == false)
        {
            lightData.isLighting = true;//Litghtが点灯している。

            //HandLightを消灯。デクリメント;
            while(HandLightComponet.intensity > 0.0f)
            {
                HandLightComponet.intensity -= LightCount;
                yield return new WaitForSeconds(LightWaitTime);
            }
            
            //Nossingオブジェクトを表示しています。
            if(_NossingObj == null)
            {
                Debug.LogError("Nullだよ");
            }
            else
            {
                for(int i = 0; i < _NossingObj.Length; i++)
                {
                    _NossingObj[i].SetActive(true);
                }
            }
            
            yield return new WaitForSeconds(0.5f);

            //MainLightを徐々に点灯。インクリメント
            while(MainLightComponet.intensity < LightLebel)
            {
                MainLightComponet.intensity += LightCount;
                yield return new WaitForSeconds(LightWaitTime);
            }

            Debug.Log("ライトアップ！！");
        }
        //ライトが点灯していたら
        else if (lightData.isLighting == true)
        {
            lightData.isLighting = false;//Litghtが消灯している。

            //MainLightを徐々に消灯。デクリメント;
            while(MainLightComponet.intensity > 0.0f)
            {
                MainLightComponet.intensity -= LightCount;
                yield return new WaitForSeconds(LightWaitTime);
            }


            //Nossingオブジェクトを非表示にしています。
            if(_NossingObj == null)
            {
                Debug.LogError("Nullだよ");
            }
            else
            {
                for(int i = 0; i < _NossingObj.Length; i++)
                {
                    _NossingObj[i].SetActive(false);
                }
            }

            yield return new WaitForSeconds(0.5f);

            //HandLightを点灯。インクリメント;
            while(HandLightComponet.intensity < LightLebel)
            {
                HandLightComponet.intensity += LightCount;
                yield return new WaitForSeconds(LightWaitTime);
            }

            Debug.Log("ライト消灯！！");
        }

        isPlaing   = false;//判定を元の状態にする。
        
        Debug.Log($"isPlaing is {isPlaing}");

    }
}
