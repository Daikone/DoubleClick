using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject[] options;
    int index=0;

    [SerializeField]
    float timer=1.5f;

    float timerSave;
    bool isChoice = false;
    List<SpriteRenderer> renderers = new List<SpriteRenderer>();
    GameObject ThePuzzle;
    int countclicks;
    public int[] difficulties;
    void Start()
    {
        timerSave = timer;
        ThePuzzle = GameObject.FindGameObjectWithTag("MainPuzzle");

        if (ThePuzzle != null)
            ThePuzzle.SetActive(false);
        else
            Debug.LogError("Please add a puzzle in the scene with the tag 'MainPuzzle'");

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
    {if(isChoice)
        {
            if(timer==timerSave)
                SetTransparency();

            timer -= Time.deltaTime;
            if (timer <= 0)
            {

                timer = timerSave;
                index++;
                if (index >= options.Length)
                    index = 0;
               
                
            }
            if (Input.GetKeyDown(GameManager.Rkey))
            {
                countclicks++;

                if (countclicks > 1)
                    StartPuzzle();
            }
        }
        
    }
    public void SetChoice(bool ch)
    {
        isChoice = ch;
    }
    //this function sets up the transparency of the puzzle pieces 
    void SetTransparency()
    {
        for(int i = 0; i < renderers.Count; i++)
		{
            renderers[i].color = index == i ? new Color(renderers[index].color.r, renderers[index].color.g, renderers[index].color.b, 1) 
                : new Color(renderers[index].color.r, renderers[index].color.g, renderers[index].color.b, 0.5f);
        }
    }
    //activates puzzles
    void StartPuzzle()
    {
        Debug.Log(difficulties[index]);
        ThePuzzle.SetActive(true);

    }
}
