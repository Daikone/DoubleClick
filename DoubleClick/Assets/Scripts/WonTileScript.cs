using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WonTileScript : MonoBehaviour
{
    public Image message;

    public DataManager datamanager;

    
    public int SaveIndex;
    // Start is called before the first frame update
    void Start()
    {
        datamanager.Load();
        message.gameObject.SetActive(false);
    }

   public void ShowMessage()
    {
        message.gameObject.SetActive(true);
    }
    //this is a placeholder function. The function will be updated after a group meeting
    public void ClickSet(int index)
    {

        switch (index)
        {
            case 0:
                datamanager.data.controlsSet = true;
                break;
            case 1:
                datamanager.data.Venice = true;
                break;
            case 2:
                datamanager.data.Berlin = true;
                break;
            case 3:
                datamanager.data.Venice = false;
                datamanager.data.Berlin = false;
                break;
            default:
                break;
        }
  
    }
    public void SaveMethod()
    {
        datamanager.Save();
    }
}
