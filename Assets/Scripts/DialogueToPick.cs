using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// L'ENUM SEQUENCE SE TROUVE DANS LE GM

public class DialogueToPick : MonoBehaviour
{
    public Sequence currentSequence = Sequence.investigation1;

    // NOMBRE DE FOIS QU'ON PARLE A TEL PERSO (REMIS A 0 A UN CHANGEMENT DE SEQUENCE)

    public int nbJerome = 0;
}