using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public bool isDialogueOn = false;
    public Canvas dialogueUI = null;
    public Image persoUI1, persoUI2, persoUI3;
    public Sprite invisiSprite;
    public TextMeshProUGUI textUI, textUIShadow, nameUI, nameUIShadow;
    public int dialogueIndex = 0;
    public Dialogue[] allDialogues;
    private Dialogue currentDialogue;
    private CharacterTemplate charaTemplate;

    [SerializeField]
    private CharacterTemplate[] allCharaTemplates;

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
        ImagesZero();
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
            AssignationImage(currentDialogue.dialogue[dialogueIndex].quiParle, currentDialogue.dialogue[dialogueIndex].emotionDuPerso, persoUI1);
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
                AssignationImage(currentDialogue.dialogue[dialogueIndex].quiParle, currentDialogue.dialogue[dialogueIndex].emotionDuPerso, persoUI1);
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
            ImagesZero();
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

    private void ImagesZero()
    {
        persoUI1.sprite = invisiSprite;
        persoUI2.sprite = invisiSprite;
        persoUI3.sprite = invisiSprite;
    }

    public void AssignationImage(Character talkingChar, Emotion currentEmotion, Image uiImageToChange)
    {
        if (talkingChar != Character.player)
        {
            CharacterTemplate CharacterTemplateToCheck = CharacterTemplateSelector(talkingChar);

            switch (currentEmotion)
            {
                case Emotion.neutre:
                    if (CharacterTemplateToCheck.spriteNeutre.emotionSprite != null)
                    {
                        uiImageToChange.sprite = CharacterTemplateToCheck.spriteNeutre.emotionSprite;
                    }
                    break;

                case Emotion.heureux:
                    if (CharacterTemplateToCheck.spriteHeureux.emotionSprite != null)
                    {
                        uiImageToChange.sprite = CharacterTemplateToCheck.spriteHeureux.emotionSprite;
                    }
                    break;

                case Emotion.triste:
                    if (CharacterTemplateToCheck.spriteTrsite.emotionSprite != null)
                    {
                        uiImageToChange.sprite = CharacterTemplateToCheck.spriteTrsite.emotionSprite;
                    }
                    break;

                case Emotion.reflexion:
                    if (CharacterTemplateToCheck.spriteReflexion.emotionSprite != null)
                    {
                        uiImageToChange.sprite = CharacterTemplateToCheck.spriteReflexion.emotionSprite;
                    }
                    break;

                case Emotion.colere:
                    if (CharacterTemplateToCheck.spriteColere.emotionSprite != null)
                    {
                        uiImageToChange.sprite = CharacterTemplateToCheck.spriteColere.emotionSprite;
                    }
                    break;

                case Emotion.inquiet:
                    if (CharacterTemplateToCheck.spriteInquiet.emotionSprite != null)
                    {
                        uiImageToChange.sprite = CharacterTemplateToCheck.spriteInquiet.emotionSprite;
                    }
                    break;

                case Emotion.intrigue:
                    if (CharacterTemplateToCheck.spriteIntrigue.emotionSprite != null)
                    {
                        uiImageToChange.sprite = CharacterTemplateToCheck.spriteIntrigue.emotionSprite;
                    }
                    break;

                case Emotion.surpris:
                    if (CharacterTemplateToCheck.spriteSurpris.emotionSprite != null)
                    {
                        uiImageToChange.sprite = CharacterTemplateToCheck.spriteSurpris.emotionSprite;
                    }
                    break;

                case Emotion.cursed:
                    if (CharacterTemplateToCheck.spriteCursed.emotionSprite != null)
                    {
                        uiImageToChange.sprite = CharacterTemplateToCheck.spriteCursed.emotionSprite;
                    }
                    break;

                default:
                    Debug.LogWarning("DialogueManager.AssignationImage - aucune image correspondante trouvée\ntalkingcharacter : " + talkingChar + "\ncurrentEmotion : " + currentEmotion + "\ncharacterTemplateToCheck : " + CharacterTemplateToCheck);
                    break;
            }
        }
    }

    public CharacterTemplate CharacterTemplateSelector(Character characterEnum)
    {
        CharacterTemplate currentCharacterTemplate = null;

        if (talkingCharacter != Character.player)
        {
            for (int i = 0; i < allCharaTemplates.Length; i++)
            {
                if (allCharaTemplates[i].character == characterEnum)
                {
                    currentCharacterTemplate = allCharaTemplates[i];
                }
            }

            if (currentCharacterTemplate == null)
            {
                Debug.LogWarning("DialogueManager.CharacterTemplateSelector: aucun template trouvé");
            }
        }

        return currentCharacterTemplate;
    }
}