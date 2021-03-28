using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float health;
    public int knock;
    public float dmg;
    
    // Start is called before the first frame update
    void Start()
    {
        if (knock == 0)
            knock = 1;
        if(health<=0)
        health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Destroy(this.gameObject);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name== "symbolPrefab(Clone)")
        {
            health -= collision.gameObject.GetComponent<symbolScrypt>().dmg+GameManager.bonusDmg;
        }
        
    }

}
