using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProj : MonoBehaviour
{// Start is called before the first frame update
    public float dmg;
    public bool isDestructable;
   
    float init;
    Quaternion angle;
    public float speed;
    void Start()
    {
        angle = Quaternion.identity;
        angle.eulerAngles = new Vector3(0, 0, init);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        transform.rotation = angle;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {

            collision.gameObject.GetComponent<enemy>().health -= dmg;
            this.gameObject.SetActive(false);
        }
    }
    public void SetAngle(float a)
    {
        init = a;
    }
}
