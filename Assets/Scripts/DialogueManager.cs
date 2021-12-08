using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public bool isDialogueOn = false;
    public Canvas dialogueUI = null;
    public Text textUi = null;
    public int dialogueIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        Canvas[] listOfCanvas = FindObjectsOfType<Canvas>();
        foreach (Canvas currentCanvas in listOfCanvas)
        {
            if (currentCanvas.tag == "DialogueUI")
            {
                dialogueUI = currentCanvas;
            }
        }

        if (dialogueUI != null)
        {
            dialogueUI.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DialogueBegin(Dialogue d)
    {
        isDialogueOn = true;
        dialogueUI.enabled = true; 
        dialogueIndex = 0;
        textUi.text = d.dialogue[dialogueIndex];
    }

    public void NextString(Dialogue d)
    {
        dialogueIndex++;
        if(dialogueIndex + 1 > d.dialogue.Length)
        {
            DialogueEnd();
            return;
        }

        string newString = NameChanger(d.dialogue[dialogueIndex]);

        textUi.text = newString;
    }

    public string NameChanger(string s)
    {
        if (s[0] == '[')
        {
            char characterLetter = s[1];

            if (characterLetter == 'J')
            {
                s = s.Replace("[J]", "");

                //CHANGER LE TEXT EN JEROME ET LA COULEUR EN BLEU PIGEON
            } // AJOUTER LES AUTRES LETTRES POUR LES AUTRES PERSOS ET CHECKER COMMENT FAIRE UN SWITCH CASE            
        }

        return s;
    }

    public void DialogueEnd()
    {
        isDialogueOn = false;
        dialogueUI.enabled = false;
    }

}
