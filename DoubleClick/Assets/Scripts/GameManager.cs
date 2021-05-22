using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{//the keys used in the whole project
    public static KeyCode Lkey=KeyCode.Mouse0;
    public static KeyCode Rkey = KeyCode.Mouse1;
    public static bool canMove = true;
    public static bool optionAvailable = false;
    public static int saidIndex;
    public static bool wasSolved=false;
    //money and other stuf
    public float money = 0;
    
    // Start is called before the first frame update
    public static void setButtons(KeyCode l,KeyCode r)
    {
        Lkey = l;
        Rkey = r;
        
    }
   
}
