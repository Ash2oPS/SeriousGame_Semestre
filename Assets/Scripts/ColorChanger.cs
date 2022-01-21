using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private DialogueManager dm;
    private SpriteRenderer sr;

    private void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor(int newColor)
    {
        if (newColor == 0)
        {
            sr.color = Color.white;
        }
        else if (newColor == 1 && !dm.isDialogueOn)
        {
            sr.color = Color.yellow;
        }
    }

    private void Update()
    {
        if (dm.isDialogueOn)
        {
            sr.color = Color.white;
        }
    }
}