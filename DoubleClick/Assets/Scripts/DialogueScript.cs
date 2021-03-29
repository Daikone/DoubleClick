﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    public GameObject dbox;
    public Text dText;
    public Text dNames;
    public bool dialogActive;
    public string[] dialogLines;
    public string[] dialogNames;
    public int currentLine;
    public bool thereDialogue;

    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if ( Input.GetKeyDown(GameManager.Rkey))
        {

            currentLine++;
        }

        if (currentLine >= dialogLines.Length)
        {
            HideDialogue();

        }
        dNames.text = dialogNames[currentLine];
        dText.text = dialogLines[currentLine];
    }
    public void ShowBox()
    {
        dialogActive = true;
        dbox.SetActive(true);
       
    }
    public void ShowDialogue()
    {
        dialogActive = true;
        dbox.SetActive(true);
       
    }
    public void HideDialogue()
    {
        dbox.SetActive(false);
        dialogActive = false;
        currentLine = 0;
        GameManager.canMove = true;
    }
}