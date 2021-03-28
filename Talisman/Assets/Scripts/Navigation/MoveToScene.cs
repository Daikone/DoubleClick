using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToScene : MonoBehaviour
{
    public int sceneIndex;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (sceneIndex)
            {
                case 1:
                    SceneManager.LoadScene("Cutscene2");
                   
                    break;
                case 2:
                    SceneManager.LoadScene("ToBeContinued");
                    break;
                case 3:
                    SceneManager.LoadScene("Game2");
                    break;
                case 4:
                    SceneManager.LoadScene("PreBoss1");
                    break;
                case 5:
                    break;
                case 6:
                    break;
                default:
                    break;
            }
        }
    }
}
