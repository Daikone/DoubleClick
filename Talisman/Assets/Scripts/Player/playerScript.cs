using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigi;
    public int speed;
    public bool isCast=false;
    public GameObject symbolPrefab;
    float touchEnem= 0.5f;
    Animator anime;
    public bool AutoCast;
  
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        if(AutoCast)
        {
            Instantiate(symbolPrefab, this.transform);
            isCast = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        anime.SetBool("left", false);
        anime.SetBool("right", false);
        anime.SetBool("up", false);
        anime.SetBool("down", false);
        anime.SetBool("idle", true);

        //makes symbol
        if (Input.GetKeyDown(KeyCode.Mouse0)&& !isCast)
        {
            Instantiate(symbolPrefab,this.transform);
            isCast = true;
        }
        //movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            anime.SetBool("idle", false);
        }
        

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rigi.velocity = new Vector2(-speed - 1.5f, rigi.velocity.y);
            anime.SetBool("left", true);
        }
        else
            rigi.velocity = new Vector2(0, rigi.velocity.y);

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rigi.velocity = new Vector2(speed + 1.5f, rigi.velocity.y);
            anime.SetBool("right", true);
        }


        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rigi.velocity = new Vector2(rigi.velocity.x, speed + 1.5f);
            anime.SetBool("up", true);
        }
        else
            rigi.velocity = new Vector2(rigi.velocity.x, 0);
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rigi.velocity = new Vector2(rigi.velocity.x, -speed - 1.5f);
            anime.SetBool("down", true);
        }
        if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)) || (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)))
        {
            rigi.velocity = new Vector2(0, rigi.velocity.y);
            anime.SetBool("idle", true);
            
        }
        if ((Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)))
        {
            rigi.velocity = new Vector2(rigi.velocity.x, 0);
            anime.SetBool("idle", true);
        }
        //gamme over
        if(GameManager.health<=0)
        {

            GameManager.GameOver();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==8)
        {
            GameManager.health -= collision.gameObject.GetComponent<enemy>().dmg;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            touchEnem -= Time.deltaTime;
            if (touchEnem <= 0)
            { GameManager.health -= collision.gameObject.GetComponent<enemy>().dmg;
                touchEnem = 0.5f;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            touchEnem = 0.5f;
        }
    }
    
}
