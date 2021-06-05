﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleActivator : MonoBehaviour
{
 
    
    static bool hasActivated=false;
    bool puzSolved=true;

    static GameObject puzzleBKG;
    GameObject player;
    static AccessPuzzle puz;
    GameObject puzzle;

    [SerializeField]
    GameObject Easy;
    [SerializeField]
    GameObject Medium;
    [SerializeField]
    GameObject Hard;



    int delay = 0;
   
    void Awake()
    {
        puzzleBKG =GameObject.Find("PuzzleBkg");
        player = GameObject.FindGameObjectWithTag("Player");
        puzzleBKG.SetActive(false);
    }

    
    //used by other functions to save the puzzle selector the player is on
    public static void Setpuzzle(AccessPuzzle a)
    {
        puz = a;

    }
    public static void SetInactive()
    {
        GameManager.canMove = true;
        hasActivated = false;
        puzzleBKG.SetActive(false);
    }
     public void StartPuzzle()
    {
        
        puzzleBKG.SetActive(true);

        switch (puz.difficulty)
        {
            default:
            case 0:
                puzzle = Instantiate(Easy, puzzleBKG.transform);
                break;
            case 1:
                puzzle = Instantiate(Medium, puzzleBKG.transform);
                break;
            case 2:
                puzzle = Instantiate(Hard, puzzleBKG.transform);
                break;
        }
        puzzle.transform.position = new Vector3(puzzle.transform.position.x, puzzle.transform.position.y+2, puzzle.transform.position.z);
        
       
        hasActivated = true;


    }
    
}
