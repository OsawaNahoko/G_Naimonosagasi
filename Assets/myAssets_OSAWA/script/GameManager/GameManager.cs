using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]Text AllObjectText;
    [SerializeField] AllObjectData allObjectData;
    string ActiveSceneName;
    // Start is called before the first frame update
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
}
