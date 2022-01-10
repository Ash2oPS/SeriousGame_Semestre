using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Room
{
    room1
}

public class GameManager : MonoBehaviour
{
    public Room currentRoom;

    private void Start()
    {
        currentRoom = Room.room1;
    }
}