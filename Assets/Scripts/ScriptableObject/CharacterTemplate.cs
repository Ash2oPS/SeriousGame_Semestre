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

    public EmotionsToSprite spriteNeutre = new EmotionsToSprite(Emotion.neutre, null);
    public EmotionsToSprite spriteHeureux = new EmotionsToSprite(Emotion.heureux, null);
    public EmotionsToSprite spriteTrsite = new EmotionsToSprite(Emotion.triste, null);
    public EmotionsToSprite spriteReflexion = new EmotionsToSprite(Emotion.reflexion, null);
    public EmotionsToSprite spriteColere = new EmotionsToSprite(Emotion.colere, null);
    public EmotionsToSprite spriteInquiet = new EmotionsToSprite(Emotion.inquiet, null);
    public EmotionsToSprite spriteIntrigue = new EmotionsToSprite(Emotion.intrigue, null);
    public EmotionsToSprite spriteSurpris = new EmotionsToSprite(Emotion.surpris, null);
    public EmotionsToSprite spriteCursed = new EmotionsToSprite(Emotion.cursed, null);

    public List<AudioClip> voice;

    public Dialogue defaultDialogue;
    public DialogueChoiceBySwitch[] dialogueChoiceBySwitches;
}