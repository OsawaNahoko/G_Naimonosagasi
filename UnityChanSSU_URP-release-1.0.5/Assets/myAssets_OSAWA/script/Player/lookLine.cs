using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class lookLine : MonoBehaviour
{
    [SerializeField] Color color;//アウトラインカラー;
    GameObject CollgameObject;  //衝突したオブジェクトを入れておく変数。;
    Outline Collobjeoutline;    //AddしたｓOutlineを入れておく変数;

    // Update is called once per frame
    void  OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "NossingObject" || collision.gameObject.tag == "GameObject")
        {
            if (Collobjeoutline != null)
            {
                Destroy(this.Collobjeoutline);
            }
            Debug.Log("GameObjectLine 反応しました");
            this.CollgameObject = collision.gameObject;

        if(CollgameObject == null)
        {
            Debug.LogError("CollgameObject is null");
            return;
        }
        else
        {
            CollgameObject.AddComponent<Outline>();
            CollgameObject.AddComponent<testScript>();
            Collobjeoutline =  CollgameObject.GetComponent<Outline>();
        }
  
        // Outline の設定
        if (Collobjeoutline != null)
        {
            Collobjeoutline.OutlineColor = color;
            Collobjeoutline.OutlineWidth = 10.0f;
        }
        else
        {
            Debug.LogError("Collobjectline is null");
        }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (Collobjeoutline != null)
        {
            Destroy(this.Collobjeoutline);
        }
        CollgameObject = null;

    }
}
