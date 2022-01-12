using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue", fileName = "NewDialogue", order = 0)]
public class Dialogue : ScriptableObject
{
    public Dialogue_Struct[] dialogue;
}