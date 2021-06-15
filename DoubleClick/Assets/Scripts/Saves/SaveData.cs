using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This function ontains the data for the json file. Here the values used for the progress save will be made
/// </summary>
[System.Serializable]
public class SaveData 
{
    //the values here MUST match the vlues in the JSOn file in both number and names
    

    public bool controlsSet;

    public bool Venice;

    public bool Berlin;
    public KeyCode Rinput;
    public KeyCode Linput;



}
