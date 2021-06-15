using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectControls : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName;
    int keys = 0;
    Text texte;
    public DataManager data;
    void Start()
    {
        texte = GetComponent<Text>();
        texte.text = "Press your left input.";
    }

    // Update is called once per frame
    void OnGUI()
    {
        Event e = Event.current;
        Debug.Log(e.keyCode);
        if (e.isKey && e.keyCode != KeyCode.None)
        {
            
            
            if (keys == 1)
            {
                data.data.Linput = e.keyCode;
                
                texte.text = "Now press your right input.";
            }
            if (keys == 2)
            {
                data.data.Rinput = e.keyCode;
            

            }
            if (keys == 3)
            {
                GameManager.Lkey = data.data.Linput;
                GameManager.Rkey = data.data.Rinput;
                data.data.controlsSet = true;
                data.Save();
                SceneManager.LoadScene(sceneName); }

            keys++;
        }
        
    }
    void KeyDown()
    {

    }
}
