using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public DataManager data;
    public MenuButton Berlin;
    public MenuButton Venice;
    void Start()
    {
        data.Load();
        Berlin.Enabled = data.data.Berlin;
        Venice.Enabled = data.data.Venice;
        

    }

    
}
