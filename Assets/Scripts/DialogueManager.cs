using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public bool isDialogueOn = false;
    public Canvas dialogueUI = null;
    public TextMeshProUGUI textUI, textUIShadow, nameUI, nameUIShadow;
    public int dialogueIndex = 0;
    public Dialogue[] allDialogues;
    private Dialogue currentDialogue;
    private CharacterTemplate charaTemplate;
    public Character talkingCharacter;
    public SwitchManager switchMan;

    // Start is called before the first frame update
    private void Awake()
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

    private void DialoguePicker()
    {
        for (int i = charaTemplate.dialogueChoiceBySwitches.Length - 1; i >= 0; i--)
        {
            var dcs = charaTemplate.dialogueChoiceBySwitches[i];
            if (switchMan.CheckSwitch(dcs._switchIDs))
            {
                currentDialogue = dcs._dialogue;
            }
        }
        currentDialogue = charaTemplate.defaultDialogue;
    }

    public void DialogueBegin(CharacterTemplate ct)
    {
        charaTemplate = ct;
        DialoguePicker();
        talkingCharacter = ct.character;
        if (!isDialogueOn)
        {
            isDialogueOn = true;
            dialogueUI.enabled = true;
            dialogueIndex = 0;
        }
        NextString();
    }

    public void NextString()
    {
        nameUI.text = currentDialogue.dialogue[dialogueIndex].quiParle.ToString();
        nameUIShadow.text = currentDialogue.dialogue[dialogueIndex].quiParle.ToString();
        textUI.text = currentDialogue.dialogue[dialogueIndex].replique;
        textUIShadow.text = currentDialogue.dialogue[dialogueIndex].replique;
        dialogueIndex++;
        if (dialogueIndex + 1 > currentDialogue.dialogue.Length)
        {
            DialogueEnd();
            return;
        }
    }

    public void DialogueEnd()
    {
        if (isDialogueOn)
        {
            isDialogueOn = false;
            dialogueUI.enabled = false;

            DialogueToPick dtp = FindObjectOfType<DialogueToPick>();
            switchMan.SetSwitch(currentDialogue.switchToSetToTrue, true);
        }
    }
}