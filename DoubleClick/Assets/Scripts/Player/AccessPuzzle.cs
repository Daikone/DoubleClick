using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessPuzzle : MonoBehaviour
{
    
    /// Lists and arrays
    //the array where the puzzle piece objects are put
    public GameObject[] options;
    //array of difficulties for each puzzle
    public int[] difficulties;
    //list of the spriterenderers for the options
    List<SpriteRenderer> renderers = new List<SpriteRenderer>();


    /// Variables
    public int index =0;
    int count = 0;
    [SerializeField]
    float timer=1.5f;

    float timerSave;
    public bool isChoice = false;
    //the puzzle parent object
    GameObject ThePuzzle;
    //used to delay the appearane of the puzzles
    int countclicks;
    
    void Awake()
    {
        timerSave = timer;
        ThePuzzle = GameObject.FindGameObjectWithTag("MainPuzzle");
        
        //sets thepuzzles to look transparent
        for (int i = 0; i < options.Length; i++)
        { renderers.Add(options[i].GetComponent<SpriteRenderer>());
            renderers[i].color = new Color(renderers[index].color.r, renderers[index].color.g, renderers[index].color.b, 0.5f);
        }
        //this is here to alert if there are enough puzzle optons
        if (difficulties.Length < options.Length)
            Debug.LogError($"There aren not enough difficulty indexes. Please add {options.Length-difficulties.Length} more indexes");

    }

    // Update is called once per frame
    void Update()
    {
        //only activates when the character is on a puzzle selection tile
        if (isChoice)
        {
            
            if (timer==timerSave)
                SetEffects();

            timer -= Time.deltaTime;
            if (timer <= 0)
            {

                timer = timerSave;
                index++;
                if (index >= options.Length)
                    index = 0;
               
                
            }
            if (Input.GetKeyDown(GameManager.Rkey))
                count++;
            if (count == 2)
            {
                
                PuzzleActivator.Setpuzzle(this);
                StartPuzzle();
                Deactivate();
                isChoice = false;
                count = 0;
            }
        }

        Debug.Log(isChoice);

    }
    //removes selection effects
    void Deactivate()
    {
        for (int i = 0; i < options.Length; i++)
        {
            renderers[i].color = new Color(renderers[index].color.r, renderers[index].color.g, renderers[index].color.b, 0.5f);
            options[i].transform.localScale =  new Vector3(1, 1, 1);
        }
        count = 0;
    }
    public void SetChoice(bool ch)
    {
        isChoice = ch;
    }
    //this function sets up the visual effects of the puzzle pieces 
    void SetEffects()
    {
        for(int i = 0; i < renderers.Count; i++)
		{
            renderers[i].color = index == i ? new Color(renderers[index].color.r, renderers[index].color.g, renderers[index].color.b, 1) 
                : new Color(renderers[index].color.r, renderers[index].color.g, renderers[index].color.b, 0.5f);
            options[i].transform.localScale = index == i ? new Vector3(1.2f, 1.2f, 1) : new Vector3(1, 1, 1);
        }
    }
    //activates puzzles
    void StartPuzzle()
    {
        GameManager.canMove = false;
        ThePuzzle.SetActive(true);
        ThePuzzle.GetComponent<PuzzleActivator>().StartPuzzle();

    }
}
