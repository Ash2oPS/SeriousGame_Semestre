using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Room
{
    room1
}

public enum Sequence
{
    intro, investigation1, resolution1, investigation2, resolution2, investigation3, resolution3, fin
}

public enum Character
{
    none, jerome, nathalie, axel, nico, louis, thibault, selene, player
    //jerome pigeon, nathalie souris, axel pieuvre, nico morse, louis aigle, thibault tortue, selene lapine
}

public enum Emotion
{
    neutre, heureux, triste, reflexion, colere, inquiet, intrigue, surpris, cursed
}

public enum DialAnimation
{
    none, secousse
}

public enum DialEvent
{
    none, entreeDe, sortieDe
}