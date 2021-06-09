using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FreeplayTiles : MonoBehaviour
{
    // Start is called before the first frame update
    public ST_PuzzleDisplay puzzle;

    public Texture[] PossibleImages;


    void Start()
    {
        if (PossibleImages.Length > 0)
        {
            int rInt = Random.Range(0, PossibleImages.Length);
            puzzle.PuzzleImage = PossibleImages[rInt];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzle.Complete)
            SceneManager.LoadScene("FreePlayMenu");
        
    }
}
