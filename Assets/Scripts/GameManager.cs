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

public class GameManager : MonoBehaviour
{
    public Room currentRoom;

    private void Start()
    {
        currentRoom = Room.room1;
    }
}