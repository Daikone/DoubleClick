using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickButtons : MonoBehaviour
{
    // Start is called before the first frame update
    Image leftPrompt;
    Image rightPrompt;
    void Start()
    {
        leftPrompt = GameObject.Find("leftPrompt").GetComponent<Image>();
        rightPrompt = GameObject.Find("rightPrompt").GetComponent<Image>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(GameManager.Lkey))
        {
            //this is where the game exits
        }
        if (Input.GetKeyDown(GameManager.Rkey))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
