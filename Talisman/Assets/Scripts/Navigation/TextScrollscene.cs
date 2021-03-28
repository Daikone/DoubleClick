using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextScrollscene : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] dialogue;
    int length;
    Text texto;
    int i ;
    public string TargetScene;
    void Start()
    {
        texto = GetComponent<Text>();
        length = dialogue.Length;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log(i);
            if (i < dialogue.Length)
             texto.text = dialogue[i];
            else
                SceneManager.LoadScene(TargetScene);
            i++;
        }
        
       
       
    }
}
