using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Debug : MonoBehaviour
{
    [SerializeField]
    private GameManager gm;
    [SerializeField]
    private DialogueManager dm;
    [SerializeField]
    private TextMeshProUGUI tmproDebug;

    private void Update()
    {
        if (gm.Debug)
        {
            tmproDebug.text = "Current talking : " + dm.talkingCharacter;
        }
    }
}
