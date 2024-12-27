using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class portal : MonoBehaviour
{
    // [SerializeField] LightData lightData;//LightData
    // [SerializeFIeld] Text scoreLabel;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("NossingObject"))
        {
            Debug.Log("NossingObject is Coll");
            GameObject CollgameObject = collision.gameObject;
            if(CollgameObject != null)
            {
                //NossingObuject を　削除します,
                Destroy(CollgameObject);
            }
            else
            {
                Debug.LogError("例外が発生しました");
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
                var force = new Vector3(0.0f,5.0f,0.0f);
                rb.AddForce(force);
            }
            else
            {
                Debug.LogError("例外が発生しました");
            }
        }
  

    }

    // Update is called once per frame
    void Update()
    {
  

    }
}
