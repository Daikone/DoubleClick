using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static Inventory inventory = new Inventory();
    public static float maxHealth = 100;
    public static float health = maxHealth;
    int saveId = 0;
    public static float addRange;
    public static string LastScene;
    public static float extraHeal;
    public static float bonusDmg=0;
    public static bool EnableProj=false;
    public static void GameOver()
    {
        LastScene= SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("GameOver");
    }
    public static int projIndex;
    
    public static void StartGame()
    {

    }
    public static void MakeSave()
    {

    }
}
