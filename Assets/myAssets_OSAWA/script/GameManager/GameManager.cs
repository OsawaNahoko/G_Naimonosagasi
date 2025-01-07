using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]Text AllObjectText;
    [SerializeField] AllObjectData allObjectData;
    [SerializeField] UnityEvent events;

    string ActiveSceneName;

    void Start()
    {
        ActiveSceneName = SceneManager.GetActiveScene().name;

        if(ActiveSceneName == "2_1_GameClear")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        

        if(AllObjectText != null)
        {
            int NossingCount = GameObject.FindGameObjectsWithTag("NossingObject").Length;
            AllObjectText.text = $"/{NossingCount}";
            allObjectData.AllObjectCount = NossingCount;
        }
        else
        {
            Debug.Log("AllObjectText is null");
        }
    }

    void Update()
    {
        if(ActiveSceneName == "0_1_title")
        {
            if( Input.GetButtonDown("Fire1"))
            {
                Debug.Log("処理を検知");
                this.events.Invoke();
            }
        }

    }

}
