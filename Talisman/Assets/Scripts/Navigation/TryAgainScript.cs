using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TryAgainScript : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        switch (GameManager.LastScene)
        {
            case "Game1":
                GameManager.inventory = new Inventory();
                SceneManager.LoadScene("Game1");
                break;
            case "Game2":
                SceneManager.LoadScene("PreBoss1");
                break;
            default:
                break;
        }
        GameManager.health = GameManager.maxHealth;
    }
}
