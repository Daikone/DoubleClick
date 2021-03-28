using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToBeContinued : MonoBehaviour
{
    // Start is called before the first frame update
    Text text;
    float timer;
    void Start()
    {
        timer = 0.1f;
        text = GetComponent<Text>();
        text.color = new Color(text.color.r,text.color.g,text.color.b,0);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (text.color.a < 1)
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + 0.01f);
            else
                SceneManager.LoadScene("MainMenu");
            timer = 0.1f;
        }

    }
}
