using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetButtons : MonoBehaviour
{
    public KeyCode lkey;
    public KeyCode rkey;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.setButtons(lkey, rkey);
    }

 
}
