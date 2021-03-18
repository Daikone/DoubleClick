using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static KeyCode Lkey;
    public static KeyCode Rkey;

    public static float karma = 50;
    public float money = 0;
    // Start is called before the first frame update
    public static void setButtons(KeyCode l,KeyCode r)
    {
        Lkey = l;
        Rkey = r;
    }
}
