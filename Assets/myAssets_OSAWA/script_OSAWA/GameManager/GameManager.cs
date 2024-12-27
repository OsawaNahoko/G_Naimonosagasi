using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]Text AllObjectText;
    
    // Start is called before the first frame update
    void Start()
    {
        if(AllObjectText != null)
        {
            int NossingCount = GameObject.FindGameObjectsWithTag("NossingObject").Length;
            AllObjectText.text = $"/{NossingCount}";
        }
        else
        {
            Debug.LogError("AllObjectText is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
