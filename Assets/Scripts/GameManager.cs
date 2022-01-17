using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Room currentRoom;

    [SerializeField]
    private bool Debug;

    private void Start()
    {
        currentRoom = Room.room1;
    }
}