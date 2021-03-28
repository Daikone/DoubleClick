using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float dmg;
    public bool isDestructable;
    public Vector3 target;
    float init;
    Quaternion angle;
    public float speed;
    void Start()
    {
        angle = Quaternion.identity;
        angle.eulerAngles = new Vector3(0,0, init);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*Time.deltaTime*speed);
        transform.rotation = angle;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag == "Player")
        {
            GameManager.health -= dmg;
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerstay2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag == "Player")
        {
            GameManager.health -= dmg;

        }
    }
    
    public void SetAngle(float a)
    {
        init = a;
    }
}
