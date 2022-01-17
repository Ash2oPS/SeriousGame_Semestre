using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnCharacter : MonoBehaviour
{
    public DialogueManager dm;
    public CharacterTemplate charTemp;
    public CharacterTemplateGetter charTempGetter;

    private void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
        charTempGetter = GetComponent<CharacterTemplateGetter>();
        charTemp = charTempGetter.charTemplate;
    }

    public void click()
    {
        if (dm.talkingCharacter == Character.none)
        {
            dm.talkingCharacter = charTemp.character;
        }
    }
}