using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GenerateScript : MonoBehaviour
{
    /// ///Input fields
    //Inputs for width and height
    InputField wInput;
    InputField hInput;

    /// ///Number varables
    //Width and height of the puzzle in tiles
    int Width =2;
    int Height=2;
    //length of the side of the square slides
    int sideLength;
    //random number used in generation
    System.Random random=new System.Random();
    //int variables used for maze construction
    int x = 0;
    int y = 0;
    //maximum visual width and height of the maze
    float maxWidth = Screen.width - 10;
    float maxHeight = Screen.height - 10;
    //int variabes which keep the coordinates of the entrance
    int xE = 0;
    int yE = 0;

    /// ///lists and arrays
    //arrys used for storing tile data
    GameObject[,] tArray;
    TileScript[,] tScript;
    //This array contails the tiles which were visited
    List<int> tArrayX;
    List<int> tArrayY;

    
    /// ///object prefab
    //prefab for the tiles , the Array of tiles and the array for the scripts used for each tile
    [SerializeField]
    UnityEngine.Object tileP;

    /// /// Boolean values
    //bool value used to check whether or not there are still unvisited tiles
    bool unvis;
    //bool value used to check if an exit appeared
    bool exit=true;


    //In this function the maze data is saved and used in generating the maze
    void MakeIt()
    {
        //removes the former maze
        foreach (Transform child in this.transform)
            Destroy(child.gameObject);
        transform.localScale = new Vector3(1, 1, 1);
        exit = false;

        if (wInput.text != "" && hInput.text != "")
        {
            //creates the tile grid
            Width = Int16.Parse(wInput.text);
            Height = Int16.Parse(hInput.text);

            //creates the tile grid, which is the basis of the tiles
            tArray = new GameObject[Width, Height];
            tScript = new TileScript[Width, Height];
            for (int i = 0; i < Width; i++)
            { for (int j = 0; j < Height; j++)
                {
                    tArray[i, j] = PrefabUtility.InstantiatePrefab(tileP) as GameObject;
                    tArray[i, j].transform.SetParent(transform);
                    tScript[i, j] = tArray[i, j].GetComponent<TileScript>();

                    //sets the positions of the tiles
                     tArray[i, j].transform.position = new Vector3((tArray[i, j].transform.localScale.x-Width)/2  + i, (tArray[i, j].transform.localScale.x - Height) / 2 + j+1, 0);
                   
                    PrefabUtility.UnpackPrefabInstance(tArray[i, j], PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
                    
                }
            }

            //sets the scale of the tiles to fit in the window 
            Vector3 newScale = transform.localScale;
            if (Width* tScript[0, 0].trScale.rect.width > maxWidth)
            {
                newScale = transform.localScale;

                newScale.x = maxHeight * newScale.x / (Width * tScript[0, 0].trScale.rect.width);
                newScale.y = newScale.x;

                transform.localScale = newScale;
            }
            else if (Height * tScript[0, 0].trScale.rect.height > maxHeight)
            {

                newScale = transform.localScale;
                newScale.y = maxHeight * newScale.y / (Height * tScript[0, 0].trScale.rect.height );
                newScale.x = newScale.y;

                transform.localScale = newScale;
                
               
            }

            //sets the starting point of the puzzle
            int e = random.Next(0, 1);
            
            tScript[0, random.Next(0, Width)].visited = true;
            for (int i = 0; i < Width; i++)
            {
                if (tScript[0, i].visited)
                {
                    tArrayX.Add(0);
                    tArrayY.Add(i);
                    y = i;
                    x = 0;
                    tScript[0, i].leftWall.SetActive(false);
                    break;
                }

            }
            xE = x;
            yE=y;
          

            //starting the maze generation
            unvis = true;
            //removes the text from the input fields after it has memorized the values
            wInput.text = "";
            hInput.text = "";
        }
    }
    //Awake is called when the script loads. Used to get references to the Input fields
    void Awake()
    {
        tArrayX = new List<int>();
        tArrayY = new List<int>();
        wInput = GameObject.Find("Width").GetComponent<InputField>();
        hInput = GameObject.Find("Height").GetComponent<InputField>();
        
    }
    //function called once per frame. Here the tiles are generated
    void Update()
    {
        
        if (unvis)
        {// randomly selects neighbouring tiles and "visits them"
            int randInt = random.Next(1, 5);
            
            switch (randInt)
            {
                default:
                case 1:
                    //connect with tiles above
                    if (y + 1 < Height)
                    {
                        if (tScript[x, y].visited && !tScript[x, y + 1].visited)
                        {

                            tScript[x, y + 1].downWall.SetActive(false);
                            tScript[x, y].upWall.SetActive(false);
                            tScript[x, y+1].visited = true;
                            if (exit)
                            {
                                tScript[x, y+1].upWall.SetActive(false);
                                exit = false;
                                break;
                            }
                            SaveCoords(x, y+1);
                            
                        }
                        

                    }
                    
                    break;
                case 2:
                    //connect with tiles below
                    if (y - 1 > -1)
                    {
                        
                        if (tScript[x, y].visited &&!tScript[x, y - 1].visited)
                        {
                            tScript[x, y - 1].upWall.SetActive(false);
                            tScript[x, y].downWall.SetActive(false);
                            tScript[x, y-1].visited = true;
                            if (exit)
                            {
                                tScript[x, y - 1].downWall.SetActive(false);
                                exit = false;
                                break;
                            }
                            SaveCoords(x, y-1);
                         
                        }
                        
                    }
                    
                    break;
                case 3:
                    //connect with tiles to the left
                    if (x - 1 >-1)
                    {
                        if (tScript[x, y].visited && !tScript[x - 1, y].visited)
                        {
                            tScript[x - 1, y].rightWall.SetActive(false);
                            tScript[x, y].leftWall.SetActive(false);
                            tScript[x-1, y].visited = true;
                            SaveCoords(x-1, y );
                        }
                      
                    }
                    break;
                case 4:
                    //connect with tiles to the right
                    if (x + 1 < Width)
                    {
                        if (tScript[x, y].visited && !tScript[x + 1, y].visited)
                        {
                            tScript[x + 1, y].leftWall.SetActive(false);
                            tScript[x, y].rightWall.SetActive(false);
                            tScript[x+1, y].visited = true;
                            if (exit)
                            {
                                tScript[x+1, y].downWall.SetActive(false);
                                exit = false;
                                break;
                            }
                            SaveCoords(x + 1, y);
                            
                        }
                        
                    }
                    break;
                

            }
            RandomCoords();
            Check();
        }
    }

    //chacks whether or not there are still unchecked tiles in the maze
    void Check()
    {
        if (tArray.Length - tArrayX.Count == 1)
            exit = true;
      
        foreach (TileScript item in tScript)
        {
            if(item.visited)
            {
                unvis = false;
            }
            else
            {
                unvis = true;
                break;
            }
        }

    }

    //gives random coordinates for the tiles
    void RandomCoords()
    {
        int a=tArrayX[random.Next(0,tArrayX.Count-1)];
        int b = tArrayY[random.Next(0, tArrayY.Count - 1)]; ;
        
        

        x = random.Next(a-1, a+1);
        y = random.Next(b-1, b+1);
        if (x < 0)
            x++;
        if (x > Width-1)
            x--;
        if (y < 0)
            y++;
        if (y > Height- 1)
            y--;
    }
    void SaveCoords(int a, int b)
    {
        tArrayX.Add(a);
        tArrayY.Add(b);
    }
    
    

}
