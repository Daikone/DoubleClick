using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialArrows : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer easy;
    public SpriteRenderer hard;
    public Movement player;
   
    void Start()
    {
      


    }

    // Update is called once per frame
    void Update()
    {
        if (player.pathIndex == 1)
        {
            hard.color = new Color(hard.color.r, hard.color.g, hard.color.b, 0.5f);
            hard.gameObject.transform.localScale = new Vector3(2f, 2f, 1);

            easy.color = new Color(easy.color.r, easy.color.g, easy.color.b, 1f);
            easy.gameObject.transform.localScale = new Vector3(2.7f, 2.7f, 1);



        }
        if (player.pathIndex == 2)
        {
            hard.color = new Color(hard.color.r, hard.color.g, hard.color.b, 1f);
            hard.gameObject.transform.localScale = new Vector3(2.7f, 2.7f, 1);

            easy.color = new Color(easy.color.r, easy.color.g, easy.color.b, 0.5f);
            easy.gameObject.transform.localScale = new Vector3(2f, 2f, 1);


        }
        
       
    }
}
