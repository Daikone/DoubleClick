using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class symbolScrypt : MonoBehaviour
{
    private bool connected=true;
    Collider2D player;
    Collider2D colisionthis;
    Rigidbody2D rig;
    bool enemyCol=false;
    public float dmg = 10;
    private float time=14;
    SpriteRenderer sprit;
    symbolPool symbPool;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        colisionthis = GetComponent<Collider2D>();
        rig = GetComponent<Rigidbody2D>();
        sprit = GetComponent<SpriteRenderer>();
        symbPool = GetComponentInChildren<symbolPool>();
    }

    // Update is called once per frame
    void Update()
    {
        
        symbPool.enabled = GameManager.EnableProj;
        //movement
        Physics2D.IgnoreCollision(colisionthis,player,true);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (connected)
        { this.transform.position = new Vector3(worldPosition.x, worldPosition.y, this.transform.position.z);
            sprit.color = new Color(sprit.color.r, sprit.color.g, sprit.color.b,1);
            time = 14;
        }
    
        if (!connected && (worldPosition.x - transform.position.x <= 0.5f && worldPosition.y - transform.position.y <= 0.5f) && Input.GetKeyDown(KeyCode.Mouse0) && !enemyCol)
        connected = true;

        //fade
        if(!connected)
        {
            time -= Time.deltaTime;
            if(time<=4)
            sprit.color = new Color(sprit.color.r, sprit.color.g, sprit.color.b, sprit.color.a - 0.001f );
            if (time <= 0)
            { Destroy(this.gameObject);
                player.gameObject.GetComponent<playerScript>().isCast = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==8)
        {
            rig.AddForce(new Vector2(transform.position.x - collision.transform.position.x, transform.position.y - collision.transform.position.y)*100) ;
            connected = false;
            enemyCol = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            rig.AddForce(new Vector2(transform.position.x - collision.transform.position.x, transform.position.y - collision.transform.position.y) * 100);
            connected = false;
            enemyCol = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        enemyCol = false;
        
    }
}
