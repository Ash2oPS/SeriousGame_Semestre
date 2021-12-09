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

    public void DialogueBegin(Dialogue d)
    {
        if (!isDialogueOn)
        {
            isDialogueOn = true;
            dialogueUI.enabled = true;
            dialogueIndex = 0;
            string newString = NameChanger(d.dialogue[dialogueIndex]);
            textUi.text = newString;
        }
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


            if (characterLetter == 'P')                                     //PLAYER
            {
                s = s.Replace("[P]", "");

                Text[] nameTexts = FindObjectsOfType<Text>();
                foreach (Text nameText in nameTexts)
                {
                    if (nameText.transform.name == "Dialogue_NameText")
                    {
                        nameText.text = "Player";
                        nameText.color = new Vector4(0, 0, 0, 1);
                    }
                }
            }

            else if (characterLetter == 'J')                                     //JEROME
            {
                s = s.Replace("[J]", "");

                Text[] nameTexts = FindObjectsOfType<Text>();
                foreach(Text nameText in nameTexts)
                {
                    if (nameText.transform.name == "Dialogue_NameText")
                    {
                        nameText.text = "Jérôme";
                        nameText.color = new Vector4(0.4392157f, 0.5254902f, 0.6392157f, 1);
                    }
                }
            }

            Image[] portraits = FindObjectsOfType<Image>();
            foreach (Image portrait in portraits)
            {
                if (portrait.transform.name == "Dialogue_Perso")
                {
                    if (portrait.sprite.name == "Jerome")
                    {
                        portrait.GetComponent<LevitationAnimation>().frequency = 20f;
                        portrait.GetComponent<LevitationAnimation>().amplitude = 5;
                    }
                }
            }
        }

        return s;
    }

    public void DialogueEnd()
    {
        if (isDialogueOn)
        {
            isDialogueOn = false;
            dialogueUI.enabled = false;
        }
    }

}
