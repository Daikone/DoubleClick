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
    void Start()
    {
        texte = GetComponent<Text>();
        texte.text = "Press your left input.";
    }

    // Update is called once per frame
    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey && e.keyCode != KeyCode.None)
        {
            keys++;
            if (keys == 1)
            {
                GameManager.Lkey = e.keyCode;
                texte.text = "Now press your right input.";
            }
                if (keys == 2)
                {
                GameManager.Rkey = e.keyCode;

                SceneManager.LoadScene(sceneName); }
        }
        
    }
    void KeyDown()
    {

    }
}
