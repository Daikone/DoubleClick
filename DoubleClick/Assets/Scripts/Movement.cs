using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //where the data from the tiles is kept
    Transform[] tiles;
    int index=1;
    //main
    public GameObject tilesParent;
    // Start is called before the first frame update
    private void Awake()
    {
        //tiles[0] = GameObject.Find("Tile" + 0) as GameObject;
    }
    void Start()
    {
        
            tiles = tilesParent.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {  
        if(Input.GetKeyDown(GameManager.Rkey) && tiles!=null)
        {
            index++;
        }

        if (index >= tiles.Length)
            index = 1;//replace this with moving to a different scene later on

        transform.position = tiles[index].position;
        Debug.Log(tiles[index].name);
       
    }
}
