using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LimitcharactersScript : MonoBehaviour
{
    InputField input;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            RemoveLetters();
        }
    }
    //Function blocks letters from being put in the input
    void RemoveLetters()
    {
        
        char[] text = input.text.ToCharArray();
        string newy="";
        //checks to make sure the input doesn't start with a 0
        if (input.text=="0")
        {
            input.text = "";

        }
        //checks to s
        else {
            for (int i = 0; i < text.Length; i++)
            {

                if ((text[i] >= '0' && text[i] <= '9'))
                {

                    newy += text[i].ToString();
                }

            }
            input.text = newy;
           
        }
        
    }
}
