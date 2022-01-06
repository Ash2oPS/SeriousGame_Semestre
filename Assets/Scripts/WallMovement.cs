using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public bool wall_is_moving;
    public bool is_moving_up;
    public float lerp_value;
    public List<GameObject> listOfWalls;
    public float wall_height = 8.0f;
    public float wall_speed = 0.5f;
    public List<Vector3> listOfStartingPos;
    public Vector3 ending_pos;

    public void Start()
    {
        wall_is_moving = false;
        is_moving_up = false;
    }

    public void Update()
    {
        if(wall_is_moving)
        {
            lerp_value += wall_speed * Time.deltaTime;
            if(lerp_value<1)
            {
                for (int i = 0; i < listOfWalls.Count; i++)
                {
                    listOfWalls[i].transform.position = Vector3.Lerp(listOfStartingPos[i],new Vector3(0f,-wall_height,0f) + listOfStartingPos[i], lerp_value);
                }
            }
            else
            {
                wall_is_moving = false;
            }
        }
    }

    public void Switch_Walls_Position()
    {
        wall_is_moving = true;
        is_moving_up = is_moving_up ? false : true;
        lerp_value = 0;
        for(int i = 0; i < listOfWalls.Count; i++)
        {
            listOfStartingPos.Add(listOfWalls[i].transform.position);
        }
    }
}
