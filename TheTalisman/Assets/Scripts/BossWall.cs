using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWall : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject boss;
    void Start()
    {
        boss = GameObject.FindWithTag("boss");
    }

    // Update is called once per frame
    void Update()
    {
        if (boss == null)
            Destroy(this.gameObject);
    }
}
