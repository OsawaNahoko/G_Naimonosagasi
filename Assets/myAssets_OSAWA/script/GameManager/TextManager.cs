using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;
using System.Collections.Generic;

[System.Serializable]//自作のクラスをインスペクター上に表示するコード
public class TalksArray
{
    public string[] talks;
}

[System.Serializable]
public class AnimetionArray
{
    public int[] Animtion;
}

public class TextManager : MonoBehaviour
{   
    //文字を格納する場所です。
    public TMP_Text textLabel;
    //次の文字を表示するまでの時間
    public float _delayDuration = 0.1f;
    //テキストの効果音です。
    public AudioClip Text_sound;

    [Space]


    //セリフを変えるために使う配列です。
    private string[] currentTalks;


    //セリフリストです。
    [SerializeField,Header("会話リスト")]
    public TalksArray[] _talksArray;

    // [SerializeField,Header("画像リスト")]
    // public Sprite[] _SpriteArray; 

    [SerializeField] GameObject UI_GamePlay;
    [SerializeField] GameObject UI_Window;
    
    private int TextCowntn = 1;
    private int talkNum = 0;


    //新機能！？アクションです
    public event Action _action;

    //ActionにPlayTalkの機能を持たせています。
    void Start()
    {
        _action += PlayTalk;


        if (TextCowntn == 1 || TextCowntn == 2 || TextCowntn == 3)
        {
            Dialogue_1();
        }
    }
    void Dialogue_1()
    {
        //TectCowntn の値に基づいて使用する　talks　配列を選択
        currentTalks = _talksArray[TextCowntn -1].talks;

        //TalkNumをリセット
        talkNum = -1;

        //playTalkをセット。
        PlayTalk();
    }

    void PlayTalk()
    {
        if(loopCaheck())
        {
            talkNum++;

            StartCoroutine(OnStartTalk(OnFinishedTalk));
        }
    }
    
    bool loopCaheck()
    {
        if(textLabel == null)
        {
            Debug.LogError("textLabel In not assig");
           return false;
        }
        if(talkNum >= currentTalks.Length -1)
        {
            //トーク終了
            Debug.Log("Inbalid talkNum value");
            StartCoroutine(ENDTalk(1.0f));
            return false;
        }
        else
        {  
            //トーク継続
            return true;
        }
    }

    IEnumerator OnStartTalk(UnityAction callback)
    {
        //textLabelにテキストを代入しています。
        textLabel.text = currentTalks[talkNum];

         //GC Allocを最小化するためキャッシュしておく←GC　Alloccoとは？
        var delay = new WaitForSeconds(_delayDuration);

        //テキスト全体の長さ
        var length =textLabel.text.Length + 1;
        
        for (var i = 0; i < length; i++)
        {
            // 徐々に文字を表示していきます。
            textLabel.maxVisibleCharacters = i;
            //音を鳴らしています。
            AudioSource.PlayClipAtPoint(Text_sound, Camera.main.transform.position);
            //アニメーションを再生しています。
            // StartAnimation(0,"Mouth_Bool",true);
            //一定時間待機しています。
            yield return delay;
        }

        // 一定時間待機
        yield return new WaitForSeconds(1.0f);

        callback();
    }

    IEnumerator ENDTalk(float waitTime)
    {
        // 一定時間待機
        yield return new WaitForSeconds(waitTime);

        UI_Window.SetActive(false);
        UI_GamePlay.SetActive(true);

    }

    void OnFinishedTalk()
    {
        Debug.Log("会話の最後まで再生したよ");
        _action.Invoke();
    }
}