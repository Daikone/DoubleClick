using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueNPC : MonoBehaviour
{
    public string dialogue;
    private DialogueScript dMan;
    public string[] dialogueLines;
    public string[] dialogueNames;
    public Sprite Image;
    public Image portrait;
    
    public Object OptionVisuals;
    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueScript>();
        
        
        portrait.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(dMan.currentLine);
        if (dMan.currentLine > 0)
            portrait.gameObject.SetActive(true);
        else
            portrait.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            

            if (Input.GetKeyUp(GameManager.Rkey) )
                {
                    GameManager.canMove = false;
                    dMan.dialogLines = dialogueLines;
                    dMan.dialogNames = dialogueNames;
                    dMan.ShowDialogue();
                


            }
            
            

        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.canMove = false;
            dMan.dialogLines = dialogueLines;
            dMan.dialogNames = dialogueNames;
            dMan.currentLine = 0;
            dMan.ShowDialogue();
            portrait.sprite = Image;


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dMan.HideDialogue();
           
        }
    }
}