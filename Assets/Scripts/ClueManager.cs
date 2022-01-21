using System.Collections;
using System.Collections.Generic;
 using UnityEngine.UI;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    private int grid_height = 2;
    private int grid_width = 5;
    private int grid_row_height = 350;
    private int grid_column_width = 350;
    private int startingPos_grid_x = 500;
    private int startingPos_grid_y = 900;

    private int numberOfCluesFound;

    public List<GameObject> listOfClues;
    public List<GameObject> listOfCluesImages;
    public List<bool> listOfCluesBool;
    public List<Vector2> listOfPositions;

    public int currentRoom;
    public List<Vector2> listOfRoomPositions;
    public Image imagePointeur;

    public bool displayedJournal = false;
    public Image imageJournal;

    public bool displayedMap = false;
    public bool isRDC = false;
    public Image imageMap;
    public Image imageMapRDC;
    public Image imageButtonRDC;
    public Image imageButtonRDC2;


    void Start()
    {
        //image = GetComponentInChildren<Image>();
        for (int i = 0; i < listOfCluesImages.Count; i++)
        {
            listOfCluesBool.Add(false);
            /*GameObject sprite = listOfCluesImages[i];
            sprite.transform.position = new Vector3(listOfPositions[i].x, listOfPositions[i].y, 0);*/
        }
        
        imageMap.enabled = displayedMap;
        imageMapRDC.enabled = displayedMap;
        imageButtonRDC.enabled = displayedMap;
        imageButtonRDC2.enabled = displayedMap;
        imagePointeur.enabled = displayedMap;
    }

    void Update()
    {
        
    }
    public void ToggleJournal()
    {
        displayedMap = false;
        imageMap.enabled = displayedMap && !isRDC;
        imageMapRDC.enabled = displayedMap && isRDC;
        displayedJournal = !displayedJournal;
        imageJournal.enabled = displayedJournal;
        imageButtonRDC.enabled = displayedMap && !isRDC;
        imageButtonRDC2.enabled = displayedMap && isRDC;

        for (int i = 0; i < listOfCluesBool.Count; i++)
        {
            DisplayClueNumber(i);
        }
    }
    public void ToggleMap()
    {
        displayedJournal = false;
        imageJournal.enabled = displayedJournal;
        displayedMap = !displayedMap;
        imageMap.enabled = displayedMap && !isRDC;
        imageMapRDC.enabled = displayedMap && isRDC;
        imageButtonRDC.enabled = displayedMap && !isRDC;
        imageButtonRDC2.enabled = displayedMap && isRDC;
        imagePointeur.enabled = displayedMap;
    }
    public void ToggleRDC()
    {
        isRDC = !isRDC;
        imageMap.enabled = displayedMap && !isRDC;
        imageMapRDC.enabled = displayedMap && isRDC;
        imageButtonRDC.enabled = displayedMap && !isRDC;
        Debug.Log(displayedMap && isRDC);
        imageButtonRDC2.enabled = displayedMap && isRDC;
        imagePointeur.enabled = !isRDC;
    }
    private void DisplayClueNumber(int i)
    {
        GameObject sprite = listOfCluesImages[i];
        //int row = pos_number / grid_width;
        //int column = pos_number % grid_width;
        //sprite.transform.position = new Vector3 (startingPos_grid_x + column * grid_column_width, startingPos_grid_y + row * grid_row_height, 0);
        sprite.GetComponent<Image>().enabled = listOfCluesBool[i] && displayedJournal;
    }
}
