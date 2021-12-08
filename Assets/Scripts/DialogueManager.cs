using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public bool isDialogueOn = false;
    public Canvas dialogueUI = null;

    // Start is called before the first frame update
    void Awake()
    {
        Canvas[] listOfCanvas = FindObjectsOfType<Canvas>();
        foreach (Canvas currentCanvas in listOfCanvas)
        {
            if (currentCanvas.tag == "DialogueUI")
            {
                dialogueUI = currentCanvas;
            }
        }

        if (dialogueUI != null)
        {
            dialogueUI.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DialogueBegin()
    {
        isDialogueOn = true;
        dialogueUI.enabled = true;
    }

    public void DialogueEnd()
    {
        isDialogueOn = false;
        dialogueUI.enabled = false;
    }

}
