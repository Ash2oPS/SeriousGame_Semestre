using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNameInDialogue : MonoBehaviour
{
    private GameManager gm;

    public string CheckAndReplace(string replique)
    {
        gm = FindObjectOfType<GameManager>();

        for (int i = 0; i < replique.Length; i++)
        {
            if (replique[i] == '@')
            {
                replique = replique.Replace("@", gm.playerName);
            }
        }

        return replique;
    }
}