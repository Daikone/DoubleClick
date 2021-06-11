using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite selected;
    public Sprite unselected;
    
    int index=0;
    public float timer;
    float tSave;


    public GameObject buttons;
    List<MenuButton> menubuttons;
    List<MenuButton> endmenubuttons;
    List<int> deleters;
    
    List<Image> visual;

    private void Start()
    {
        menubuttons = new List<MenuButton>();
        endmenubuttons = new List<MenuButton>();
        visual = new List<Image>();
        deleters = new List<int>();
        tSave = timer;

        foreach (MenuButton e in buttons.GetComponentsInChildren<MenuButton>())
        {   if(e.Enabled==true)
            menubuttons.Add(e);
        }

        for (int i = 0; i < menubuttons.Count; i++)
        {
            Image e = menubuttons[i].GetComponentInChildren<Image>();
            visual.Add(e);
        }
        for (int i = 0; i < menubuttons.Count; i++)
        {
            if (menubuttons[i].Enabled == false)
                menubuttons.RemoveAt(i);

        }

       
    }
    

    // Update is called once per frame
    void Update()
    {
        SetVisual();
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            index++;
            
            if (index > menubuttons.Count-1)
                index = 0;


            Debug.Log(menubuttons.Count);
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
            if (menubuttons[i].Enabled != false)
                visual[i].sprite = index == i ? selected : unselected;
            
            
        }
    }
}
