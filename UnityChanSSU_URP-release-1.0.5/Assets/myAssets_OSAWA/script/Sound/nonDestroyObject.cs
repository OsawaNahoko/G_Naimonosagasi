using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nonDestroyObject : MonoBehaviour
{
    // 自身がすでにロードされているかを判定するフラグ
	private static bool isLoad = false;

    void Awake()
    {
        if (isLoad == true) 
		{
        Destroy(this.gameObject); // 自分自身を破棄して終了
    	return;

        }
        else if(isLoad == false)
        {
            isLoad = true; // ロードされていなかったら、フラグをロード済みに設定する
        }
    	
        DontDestroyOnLoad(this.gameObject); 

        // void Start()
        // {
        //     SceneManager.activeSceneChanged += OnActiveSceneChanged;
        // }

	    // void OnActiveSceneChanged ( Scene prevScene, Scene nextScene )
        //  {
            
        //  }
		// //シーンがどう変わったかで判定
    }
    
}
