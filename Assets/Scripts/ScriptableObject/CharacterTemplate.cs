using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterTemplate : ScriptableObject
{
    public Character character;
    public string nomDuPerso;
    public Sprite idleSprite;
    public float taille;
    public int characterEnumInt, nbSeqIntro, nbSeqInv1, nbSeqRes1, nbSeqInv2, nbSeqRes2, nbSeqInv3, nbSeqRes3, fin;
    public List<AudioClip> voice;

    public Dialogue defaultDialogue;
    public DialogueChoiceBySwitch[] dialogueChoiceBySwitches;

}