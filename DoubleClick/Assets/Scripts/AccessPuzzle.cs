using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] options;
    int index=0;
    float timer=1.5f;
    bool isChoice = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {if(isChoice)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {

                timer = 1.5f;
                index++;
                if (index > options.Length)
                    index = 0;

            }
            if (Input.GetKeyDown(GameManager.Rkey))
            {
                Debug.Log("you selected puzzle no:" + index);
            }
        }
        
    }
}
