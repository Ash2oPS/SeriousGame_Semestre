using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerName : MonoBehaviour
{ 
    public string Enter()
    {
        string newName = "Votre Nom";
        DialogueManager dm = FindObjectOfType<DialogueManager>();

        dm.isDialogueOn = true;


        return newName;
    }
}
