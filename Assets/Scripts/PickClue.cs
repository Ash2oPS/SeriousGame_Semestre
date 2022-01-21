using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickClue : MonoBehaviour
{
    [SerializeField]
    private int index;
    public GameObject inventoryManager;
    private ClueManager clueManager;


    // Start is called before the first frame update
    void Start()
    {
        clueManager = inventoryManager.GetComponent<ClueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pickClue()
    {
        clueManager.listOfCluesBool[index] = true;
    }
}
