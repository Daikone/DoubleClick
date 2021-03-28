using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOffer : MonoBehaviour
{
    public string dialogue;
    private Dialogscript dMan;
    public string[] dialogueLines;
    public string[] dialogueNames;
    SpriteRenderer indicator;
    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<Dialogscript>();
        indicator = gameObject.GetComponentInChildren<SpriteRenderer>();
        indicator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            if(Input.GetKeyUp(KeyCode.Mouse1))
            {
               // dMan.ShowBox(dialogue);
               if(!dMan.dialogActive)
                {
                    dMan.dialogLines = dialogueLines;
                    dMan.dialogNames = dialogueNames;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                }
                    
            }
            indicator.enabled = true;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                // dMan.ShowBox(dialogue);
                if (!dMan.dialogActive)
                {
                    dMan.dialogLines = dialogueLines;
                    dMan.dialogNames = dialogueNames;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                }

            }
            indicator.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            indicator.enabled = false;
            indicator.enabled = false;
        }
    }
}
