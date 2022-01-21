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
    private GameManager gm;
    private PlayerNameInDialogue playerNameInDial;
    private TextWriter txtWriter;

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

        gm = FindObjectOfType<GameManager>();
        playerNameInDial = FindObjectOfType<PlayerNameInDialogue>();
        txtWriter = FindObjectOfType<TextWriter>();

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
                return;
            }
        }
        currentDialogue = charaTemplate.defaultDialogue;
    }

    public void DialogueBegin(CharacterTemplate ct)
    {
        TextBoxesZero();
        charaTemplate = ct;
        DialoguePicker();
        talkingCharacter = ct.character;
        NamePicker();
        if (!isDialogueOn)
        {
            isDialogueOn = true;
            dialogueUI.enabled = true;
            dialogueIndex = 0;
            string replique = currentDialogue.dialogue[dialogueIndex].replique;
            replique = playerNameInDial.CheckAndReplace(replique);
            txtWriter.StartWriting(replique, textUI, textUIShadow);
        }
    }

    public void NextString()
    {
        if (!txtWriter.isWriting)
        {
            TextBoxesZero();
            if (dialogueIndex + 1 >= currentDialogue.dialogue.Length)
            {
                DialogueEnd();
                return;
            }
            else
            {
                dialogueIndex++;
                string replique = currentDialogue.dialogue[dialogueIndex].replique;
                replique = playerNameInDial.CheckAndReplace(replique);
                NamePicker();
                txtWriter.StartWriting(replique, textUI, textUIShadow);
            }
        }
        else
        {
            txtWriter.EndWait();
        }
    }

    public void DialogueEnd()
    {
        if (isDialogueOn)
        {
            dialogueIndex = 0;
            isDialogueOn = false;
            dialogueUI.enabled = false;
            talkingCharacter = Character.none;
            TextBoxesZero();
            DialogueToPick dtp = FindObjectOfType<DialogueToPick>();
            switchMan.SetSwitch(currentDialogue.switchToSetToTrue, true);
        }
    }

    private void NamePicker()
    {
        switch (currentDialogue.dialogue[dialogueIndex].quiParle)
        {
            case Character.axel:
                nameUI.text = "Axel";
                nameUIShadow.text = "Axel";
                break;

            case Character.jerome:
                nameUI.text = "Jérôme";
                nameUIShadow.text = "Jérôme";
                break;

            case Character.louis:
                nameUI.text = "Louis";
                nameUIShadow.text = "Louis";
                break;

            case Character.nathalie:
                nameUI.text = "Nathalie";
                nameUIShadow.text = "Nathalie";
                break;

            case Character.nico:
                nameUI.text = "Nico";
                nameUIShadow.text = "Nico";
                break;

            case Character.selene:
                nameUI.text = "Selene";
                nameUIShadow.text = "Selene";
                break;

            case Character.thibault:
                nameUI.text = "Thibault";
                nameUIShadow.text = "Thibault";
                break;

            case Character.player:
                nameUI.text = gm.playerName;
                nameUIShadow.text = gm.playerName;
                break;
        }
    }

    private void TextBoxesZero()
    {
        textUI.text = "";
        textUIShadow.text = "";
        nameUI.text = "";
        nameUIShadow.text = "";
    }
}