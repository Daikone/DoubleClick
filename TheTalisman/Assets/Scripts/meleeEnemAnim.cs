using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeEnemAnim : MonoBehaviour
{
    meleeEnem meley;
    Animator animet;
    SpriteRenderer sprit;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (TryGetComponent(out meleeEnem mely))
            animet = GetComponent<Animator>();
        meley = mely;

        player = GameObject.FindWithTag("Player");
        sprit = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (meley != null)
        {
            if (meley.violent)
                animet.SetBool("violent", true);
            if(player.transform.position.x-transform.position.x>0)
            {
                sprit.flipX = true;
            }
            else
                sprit.flipX = false;


        }
    }
}
