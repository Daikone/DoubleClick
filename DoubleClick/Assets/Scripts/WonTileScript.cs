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
    public void ClickSet(bool boo)
    {
        datamanager.data.isSaved = boo;
  
    }
    public void SaveMethod()
    {
        datamanager.Save();
    }
}
