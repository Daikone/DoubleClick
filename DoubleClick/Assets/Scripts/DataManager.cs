using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public string file = "SaveData.json";
    public SaveData data;

    //sets data on the json file
    public void Save()
    {
        string json = JsonUtility.ToJson(data);
        WriteToFile(file, json);

    }
    //retrieves data from the json file
    public void Load()
    {
        data = new SaveData();
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json,data);
        Debug.Log(json);
    }
    //reads from the save file
    string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using (StreamReader read=new StreamReader(path))
            {
                string json = read.ReadToEnd();
                return json;
            }
        }
        else
        {
            Debug.LogError("File not found");
            
        }
        return "";
    }
    
    //writes on the json
    void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream filestream = new FileStream(path, FileMode.Create);
        using (StreamWriter write = new StreamWriter(filestream))
        {
            write.Write(json);
        }
    }
    string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }

}
