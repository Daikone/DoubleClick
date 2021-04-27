using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour
{
    // Start is called before the first frame update
    Image op1;
    Image op2;
    Image op3;
    Image op4;
    int index=0;
    public float timer;
    float tSave;
    public string scene1;
    public string scene2;
    public string scene3;

    
    Image[] visual;
    void Start()
    {
        tSave = timer;

        visual = new Image[] {

        GameObject.Find("IsVisible1").GetComponent<Image>(),
        GameObject.Find("IsVisible2").GetComponent<Image>(),
        GameObject.Find("IsVisible3").GetComponent<Image>(),
        GameObject.Find("IsVisible4").GetComponent<Image>(),
        };

      //string test=$"IsVisible{index}";  
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            
            timer = tSave;
            index++;
            if (index > 3)
                index = 0;
            
        }
        for (int i = 0; i < visual.Length; i++)
        {
            visual[i].enabled = index==i? true :false;
        
        }
        if (Input.GetKeyDown(GameManager.Rkey))
        {
            switch (index)
            {
                case 0:
                    SceneManager.LoadScene(scene1);
                    break;
                case 1:
                    SceneManager.LoadScene(scene2);
                    break;
                case 2:
                    SceneManager.LoadScene(scene3);
                    break;
                case 3:
                    Application.Quit();
                    break;
                default:

                    break;
            }
            Debug.Log(index);
        }
    }
}
