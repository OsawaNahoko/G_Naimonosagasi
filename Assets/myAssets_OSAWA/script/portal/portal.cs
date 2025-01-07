using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class portal : MonoBehaviour
{
    [SerializeField] Transform portlTransform;
    [SerializeField] Text NossingCountText;

    [SerializeField] AllObjectData allObjectData;
    [SerializeField] GameObject GameClear;

    [SerializeField] float WaitTime;

    int NossingCount = 0;

    void Start()
    {
        // if(NossingCountText == null)
        // {
        //     Debug.LogError("NossingCountText is null");
        // }
        // if(portlTransform == null)
        // {
        //     Debug.LogError("portlTransform is null");
        // }
        // if(allObjectData == null)
        // {
        //     Debug.LogError("allObjectData is null");
        // }
        // if(GameClear == null)
        // {
        //     Debug.LogError("GameClear is null");
        // }
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("NossingObject"))
        {
            Debug.Log("NossingObject is Coll");
            GameObject CollgameObject = collision.gameObject;
            if(CollgameObject != null)
            {
                //NossingObuject を　Playerの認識外に,
                var CollObjectTrans = CollgameObject.transform;
                CollObjectTrans.position = portlTransform.position;
                NossingCount += 1;
                NossingCountText.text = $"{NossingCount}";
                if(allObjectData.AllObjectCount == NossingCount)
                {
                    GameClear.SetActive(true);
                    StartCoroutine(GameClearScene(WaitTime));
                }
            }
            else
            {
                Debug.LogError("CollgameObject is null");
            }
        }

        if(collision.CompareTag("GameObject"))
        {
            Debug.Log("GameObject is Coll");
            GameObject CollgameObject = collision.gameObject;
            if(CollgameObject != null)
            {
                //Object を　弾き飛ばします,
                var rb = CollgameObject.GetComponent<Rigidbody>();
                var force = new Vector3(5.0f,5.0f,3.0f);
                rb.AddForce(force);
            }
            else
            {
                Debug.LogError("CollgameObject is null");
            }
        }
    }

     IEnumerator GameClearScene(float WaitTime)
    {
        Debug.Log("ゲームクリアをロード");
        yield return new WaitForSeconds(WaitTime);
        SceneManager.LoadScene("2_1_GameClear");
    }
}
