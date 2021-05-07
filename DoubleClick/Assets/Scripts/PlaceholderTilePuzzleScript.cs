using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderTilePuzzleScript : MonoBehaviour
{
    // This script is meant to contain only what is needed to transiion from puzzle to adventure
    bool IsDone=true;
    GameObject plyr;
    GameObject puzSelec;
    int indexer;
    int bounceTo;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(GameManager.Rkey))
        {
            IsDone = false;

        }
        if (!IsDone)
        {
            Debug.Log("Exit");
        }

    }
    public void SetNextMove(int inder)
    {
        indexer = inder;
    }
    public void SetDestination(int next)
    {
        bounceTo = next + 1;
    }
}
