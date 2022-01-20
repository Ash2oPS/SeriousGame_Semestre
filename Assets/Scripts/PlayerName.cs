using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerName : MonoBehaviour
{
    private DialogueManager dm;
    private GameManager gm;
    private TMP_InputField inputField;
    private string newName;

    public void Enter()
    {
        dm = FindObjectOfType<DialogueManager>();
        dm.isDialogueOn = true;
    }

    private void Valider()
    {
        dm = FindObjectOfType<DialogueManager>();
        inputField = transform.Find("InputField").GetComponent<TMP_InputField>();
        gm = FindObjectOfType<GameManager>();
        string nameInField = inputField.text;

        gm.name = nameInField;
    }
}
