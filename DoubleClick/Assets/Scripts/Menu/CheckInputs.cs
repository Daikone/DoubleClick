using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckInputs : MonoBehaviour
{
    public DataManager data;

    // Start is called before the first frame update
    void Start()
    {
        data.Load();
        if (!data.data.controlsSet)
            SceneManager.LoadScene("SetControls");
        
    }

   
}
