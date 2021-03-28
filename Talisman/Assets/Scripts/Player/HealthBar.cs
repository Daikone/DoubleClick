using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    RectTransform recy;
    RawImage rw;
    float heal=3;

    
    // Start is called before the first frame update
    void Start()
    {
        recy = GetComponent<RectTransform>();
        rw = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {  if(recy.sizeDelta.x>= GameManager.health * 1.87f)
        {
            recy.sizeDelta = new Vector2(recy.sizeDelta.x-1, recy.sizeDelta.y);
        }

        if (recy.sizeDelta.x <= GameManager.health * 1.87f)
        {
            recy.sizeDelta = new Vector2(GameManager.health * 1.87f, recy.sizeDelta.y);
        }
        rw.color = new Color(0.27f + (GameManager.maxHealth - GameManager.health) * 0.01f, 1 - (GameManager.maxHealth - GameManager.health) * 0.004f, rw.color.b);
        heal -= Time.deltaTime;
        if (heal <= 0 && GameManager.health<=GameManager.maxHealth)
        { GameManager.health += 1+GameManager.extraHeal;
            heal = 3;
        }
        

    }
}
