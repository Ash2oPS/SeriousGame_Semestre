using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Room currentRoom;
    public string playerName;
    public bool Debug;

    private DialogueManager dm;
    private PlayerName playerNameScript;

    private void Start()
    {
        playerNameScript = GetComponent<PlayerName>();
        dm = FindObjectOfType<DialogueManager>();
        currentRoom = Room.room1;

        playerName = playerNameScript.Enter();
    }
}