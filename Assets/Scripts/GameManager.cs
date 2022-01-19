using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Room currentRoom;

    public bool Debug;

    private void Start()
    {
        currentRoom = Room.room1;
    }
}