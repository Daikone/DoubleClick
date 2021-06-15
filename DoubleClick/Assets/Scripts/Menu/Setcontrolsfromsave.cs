using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setcontrolsfromsave : MonoBehaviour
{
    public DataManager datea;
    // Start is called before the first frame update
    void Start()
    {
        datea.Load();
        GameManager.Lkey = datea.data.Linput;
        GameManager.Rkey = datea.data.Rinput;
    }

    
}
