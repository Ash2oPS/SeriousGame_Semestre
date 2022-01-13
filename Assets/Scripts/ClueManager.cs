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

    void Start()
    {
        for (int i = 0; i < listOfCluesImages.Count; i++)
        {
            listOfCluesBool.Add(false);
        }
    }

    void Update()
    {
        numberOfCluesFound = 0;
        for (int i = 0; i < listOfCluesBool.Count; i++)
        {
            if (listOfCluesBool[i])
            {
                numberOfCluesFound++;
                DisplayClueNumber(i, numberOfCluesFound-1);
            }
            else
            {
                listOfCluesImages[i].GetComponent<Image>().enabled = false;
            }
        }
    }

    private void DisplayClueNumber(int i, int pos_number)
    {
        GameObject sprite = listOfCluesImages[i];
        int row = pos_number / grid_width;
        int column = pos_number % grid_width;
        sprite.transform.position = new Vector3 (startingPos_grid_x + column * grid_column_width, startingPos_grid_y + row * grid_row_height, 0);
        sprite.GetComponent<Image>().enabled = true;
    }
}
