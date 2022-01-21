using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayJournal : MonoBehaviour
{
    public bool displayedJournal = true;
    public GameObject image;
    public void ToggleJournal()
    {
        displayedJournal = displayedJournal?false:true;
        image.GetComponent<Image>().enabled = displayedJournal;
    }
}
