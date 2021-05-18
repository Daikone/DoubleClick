using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    //length of the sides of the tiles
    public static float length;
    //walls
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject upWall;
    public GameObject downWall;

    //used for measuring
    public RectTransform trScale;
         
    //bool used to check if tile was visited
    public bool visited;
    void Awake()
    {
        // length = transform.localScale.x;
        trScale = GetComponent<RectTransform>();
    }

    
}
