using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Dialogue_Struct
{
    public Character quiParle;
    public Emotion emotionDuPerso;
    public string replique;
    public DialAnimation animation;
    public DialEvent evenement;
    public Character persoEvenement;
}