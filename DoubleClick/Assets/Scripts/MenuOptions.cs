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

    Image vis1;
    Image vis2;
    Image vis3;
    Image vis4;
    void Start()
    {
        tSave = timer;
        
        vis1 = GameObject.Find("IsVisible1").GetComponent<Image>();
        vis2 = GameObject.Find("IsVisible2").GetComponent<Image>();
        vis3 = GameObject.Find("IsVisible3").GetComponent<Image>();
        vis4 = GameObject.Find("IsVisible4").GetComponent<Image>();
        
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
        switch (index)
        {
            case 0:
                vis1.enabled = true;
                vis2.enabled = false;
                vis3.enabled = false;
                vis4.enabled = false;
                break;
            case 1:
                vis1.enabled = false;
                vis2.enabled = true;
                vis3.enabled = false;
                vis4.enabled = false;
                break;
            case 2:
                vis1.enabled = false;
                vis2.enabled = false;
                vis3.enabled = true;
                vis4.enabled = false;
                break;
            case 3:
                vis1.enabled = false;
                vis2.enabled = false;
                vis3.enabled = false;
                vis4.enabled = true;
                break;
            default:

                break;
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
