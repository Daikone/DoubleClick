using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    public Text bossName;
    public Image bossBar;
    public Image background;
    GameObject bossInScene;
     void Awake ()
    {
        
        ResetBar();
    }

    private void Update()
    {
        
    }
    public void ResetBar()
    {
        bossInScene = GameObject.FindGameObjectWithTag("boss");
        if (bossBar != null) {
            if (bossInScene != null)
            {
                background.enabled = true;
                bossBar.enabled = true;
                bossName.enabled = true;
            }
            else
            {
                background.enabled = false;
                bossBar.enabled = false;
                bossName.enabled = false;
            }
        }
        
    }
    public void SetImage(Sprite sprite)
    {
        background.sprite = sprite;
    }
}
