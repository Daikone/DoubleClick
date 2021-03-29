using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    public string dialogue;
    private DialogueScript dMan;
    public string[] dialogueLines;
    public string[] dialogueNames;
    
    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueScript>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            
                if (Input.GetKeyUp(GameManager.Rkey) && !dMan.dialogActive)
                {
                    // dMan.ShowBox(dialogue);
                    dMan.dialogLines = dialogueLines;
                    dMan.dialogNames = dialogueNames;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();

                }
            
            

        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

        }
    }
   
}