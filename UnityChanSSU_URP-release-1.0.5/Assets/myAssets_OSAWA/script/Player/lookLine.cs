using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class lookLine : MonoBehaviour
{
    [SerializeField] Color color;//アウトラインカラー;
    GameObject CollgameObject;  //衝突したオブジェクトを入れておく変数。;
    Outline Collobjeoutline;    //AddしたｓOutlineを入れておく変数;
    testScript TestScript;

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
                Collobjeoutline = CollgameObject.AddComponent<Outline>();
            }
            // Outline の設定
            if (Collobjeoutline != null)
            {
                Debug.Log($"TestScript is {TestScript}");

                Collobjeoutline.OutlineMode = Outline.Mode.OutlineVisible;
                Collobjeoutline.OutlineColor = Color.yellow;
                Collobjeoutline.OutlineWidth = 5f;

                // Collobjeoutline.enabled = false;
                // Collobjeoutline.enabled = true; // 強制的に再描画させる
            }
            else
            {
                Debug.LogError("Collobjectline is null");
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "NossingObject" || collision.gameObject.tag == "GameObject")
        {
        if (Collobjeoutline != null)
        {
            Destroy(this.Collobjeoutline);
        }
        CollgameObject = null;
        }
    }
}
