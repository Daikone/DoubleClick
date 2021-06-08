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


    public GameObject buttons;
    List<MenuButton> menubuttons;

    
    List<Image> visual;

    private void Awake()
    {
        menubuttons = new List<MenuButton>();
        visual = new List<Image>();
    }
    void Start()
    {
        tSave = timer;

        foreach (MenuButton e in buttons.GetComponentsInChildren<MenuButton>())
            menubuttons.Add(e);


        for (int i=0; i<menubuttons.Count;i++ )
        {
            Image e = menubuttons[i].GetComponentInChildren<Image>();
            visual.Add(e);
        }




        SetVisual();
        //string test=$"IsVisible{index}";  
    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            index++;
            
            if (index > menubuttons.Count-1)
                index = 0;
            
            SetVisual();
            
            timer = tSave;
            
        }
        
        if (Input.GetKeyDown(GameManager.Rkey) && menubuttons[index].Enabled)
        {
            if (menubuttons[index].sceneName == "Quit")
                Application.Quit();
            else
                SceneManager.LoadScene(menubuttons[index].sceneName);
        }
        else if (Input.GetKeyDown(GameManager.Rkey))
            index++;
        
           
    }
    void SetVisual()
    {
        for (int i = 0; i < visual.Count; i++)
        {
            visual[i].enabled = index == i ? true : false;

        }
    }
}
