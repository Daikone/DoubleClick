using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeEnem : MonoBehaviour
{
    // Start is called before the first frame update
    public float range;
    GameObject player;
    public bool violent = false;
    public float speed;
    float rangebase;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (speed < 1)
            speed = 1;
        rangebase = range;
    }

    // Update is called once per frame
    void Update()
    {
        range = rangebase + GameManager.addRange;
        if (Vector3.Distance(player.transform.position,transform.position)<=range)
            violent = true;
        if(violent)
        {  
           transform.position=Vector2.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
        }
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
