using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugText : MonoBehaviour
{
    private GameManager gm;
    private DialogueManager dm;
    private TextMeshProUGUI tmproDebug;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        tmproDebug = transform.Find("DebugText").GetComponent<TextMeshProUGUI>();

        if (!gm.Debug)
        {
            tmproDebug.enabled = false;
        }
        else
        {
            dm = FindObjectOfType<DialogueManager>();
        }
    }

    private void Update()
    {
        if (gm.Debug)
        {
            tmproDebug.text = "Current talking : " + dm.talkingCharacter + "\nisDialogueOn : " + dm.isDialogueOn + gm.playerName;
        }
    }
}