using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LoadSceneManager : MonoBehaviour
{ 
    //処理を呼び出すタイミングを遅らせる事が出来ます。
    public float WaitTime;

    //ゲームシーンを呼び出せます
     public void Load_GameScene(BaseEventData data)
    {
        StartCoroutine(GameScene(WaitTime));
    }
    //タイトルシーンを呼び出せます
     public void Load_TitletScene(BaseEventData data)
    {
        StartCoroutine(TitleScene(WaitTime));
    }
    //現在のシーンを再ロードします。
     public void RLoad_ActiveScene(BaseEventData data)
    {
        StartCoroutine(ReloadScene(WaitTime));
    }
    //アプリケーションを終了させる事が出来ます。
     public void Quit(BaseEventData data)
    {
        Application.Quit();
    }

     IEnumerator GameScene(float WaitTime)
    {
        Debug.Log("Gameをロード");
        yield return new WaitForSeconds(WaitTime);
        SceneManager.LoadScene("1_1_Game");
    }
     IEnumerator TitleScene(float WaitTime)
    {
        Debug.Log("Titleをロード");
        yield return new WaitForSeconds(WaitTime);
        SceneManager.LoadScene("0_1_Title");
    }
     IEnumerator ReloadScene(float WaitTime)
    {
        Debug.Log("シーンをリロード");
        yield return new WaitForSeconds(WaitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}