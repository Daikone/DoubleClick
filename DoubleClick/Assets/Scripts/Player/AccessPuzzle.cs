using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessPuzzle : MonoBehaviour
{
    
    
    public int difficulty;
    //the spriterenderer for the options
    public SpriteRenderer rendererd;


    /// Variables
    public bool isPassed = false;
    //the puzzle parent object
    GameObject ThePuzzle;
    //used to delay the appearane of the puzzles
    int countclicks;
    bool isThere;
    void Awake()
    {
        ThePuzzle = GameObject.FindGameObjectWithTag("MainPuzzle");
        isThere = true;
    }

    //removes selection effects
    void Deactivate()
    {
            rendererd.color = new Color(rendererd.color.r, rendererd.color.g, rendererd.color.b, 0.5f);
    }
    
    //activates puzzles
    public void StartPuzzle()
    {
        if(isThere)
        {
            PuzzleActivator.Setpuzzle(this);
            ThePuzzle.SetActive(true);
            ThePuzzle.GetComponent<PuzzleActivator>().StartPuzzle();
            Deactivate();
            isThere = false;
        }
            
         
    }
   
}
