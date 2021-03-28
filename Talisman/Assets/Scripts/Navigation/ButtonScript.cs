using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour, IPointerClickHandler
{
    public int function;
    // Start is called before the first frame update
   public void OnPointerClick(PointerEventData eventData)
    {

        switch (function)
        {
            case 1:
                SceneManager.LoadScene("Starting cutscene");
                break;
            case 2:
                SceneManager.LoadScene("Game1");
                break;
            case 3:
                SceneManager.LoadScene("Game2");
                break;
            case 4:
                SceneManager.LoadScene("Cutscene2");
                break;
            case 5:
                SceneManager.LoadScene("toBeContinued");
                break;
            case 6:
                SceneManager.LoadScene("PreBoss1");
                break;
            case 7:
                GameManager.health = GameManager.maxHealth;
                SceneManager.LoadScene("MainMenu");
                break;
            case 8:
                SceneManager.LoadScene("Tutorial");
                break;
            case 9:
                SceneManager.LoadScene("GameOver");
                break;
            case 10:
                SceneManager.LoadScene("GameOver");
                break;
            default:
                break;
        }
    }

    
}
