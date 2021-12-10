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
    public Dialogue[] allDialogues;
    public string talkingCharacter;

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

        Text[] textsUi = FindObjectsOfType<Text>();
        foreach(Text text in textsUi)
        {
            if(text.transform.name == "Dialogue_Text")
            {
                textUi = text;
            }
        }
    }

    public Dialogue DialoguePicker(string character)
    {
        DialogueToPick dtp = FindObjectOfType<DialogueToPick>();
        Dialogue d = null;

        if(character == "jerome")
        {
            switch (dtp.nbJerome)
            {
                case 0:
                    foreach(Dialogue dial in allDialogues)
                    {                       
                        if (dial.name == "Jerome1_DIAL")
                        {
                            d = dial;
                        }
                    }
                    break;
                case 1:
                    foreach (Dialogue dial in allDialogues)
                    {
                        if (dial.name == "Jerome2_DIAL")
                        {
                            d = dial;
                        }
                    }
                    break;
                case 2:
                    foreach (Dialogue dial in allDialogues)
                    {
                        if (dial.name == "Jerome3_DIAL")
                        {
                            d = dial;
                        }
                    }
                    break;
                case 3:
                    foreach (Dialogue dial in allDialogues)
                    {
                        if (dial.name == "Jerome4_DIAL")
                        {
                            d = dial;
                        }
                    }
                    break;
            }
        }
        else
        {
            Debug.LogWarning(transform.name + ".DialoguePicker - string parametre de nom de perso incorrect.");
        }
        
        return d;
    }

    public void DialogueBegin(string CharacterClicked)
    {
        Dialogue d = DialoguePicker(CharacterClicked);
        talkingCharacter = CharacterClicked;
        if (!isDialogueOn)
        {
            isDialogueOn = true;
            dialogueUI.enabled = true;
            dialogueIndex = 0;
            string newString = NameChanger(d.dialogue[dialogueIndex]);
            textUi.text = newString;
        }
    }

    public void NextString()
    {
        
        Dialogue d = DialoguePicker(talkingCharacter);

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


            if (characterLetter == 'P')                                         //PLAYER
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

                Image[] allPortraits = FindObjectsOfType<Image>();
                foreach (Image portrait in allPortraits)
                {
                    if (portrait.transform.tag == "Portrait") 
                    {
                        LevitationAnimation la = portrait.GetComponent<LevitationAnimation>();
                        RectTransform rt = portrait.GetComponent<RectTransform>();
                        la.frequency = 0f;
                        la.amplitude = 0f;
                        la.timer = 0f;
                        rt.position = new Vector3(la.baseX, la.baseY, la.baseZ);
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
                Image[] portraits = FindObjectsOfType<Image>();
                foreach (Image portrait in portraits)
                {
                    if (portrait.transform.tag == "Portrait")
                    {
                        if (portrait.sprite.name == "Jerome")
                        {
                            LevitationAnimation la = portrait.GetComponent<LevitationAnimation>();
                            RectTransform rt = portrait.GetComponent<RectTransform>();
                            la.frequency = 20f;
                            la.amplitude = 5f;
                        }
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

            DialogueToPick dtp = FindObjectOfType<DialogueToPick>();

            if (talkingCharacter == "jerome")
            {
                if (DialoguePicker(talkingCharacter).name == "jerome" && dtp.nbJerome == 3)
                {
                    return;
                }
                else
                {
                    dtp.nbJerome++;
                }
            }
            talkingCharacter = "";

        }
    }

}
