using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnTarget : MonoBehaviour
{
    //private GameObject originalGameObject;
    //public GameObject child;

    [Range(0f, 360f)]
    public float rotationCam_x = 0.0f;
    [Range(0f, 360f)]
    public float rotationCam_y = 0.0f;
    [Range(0f, 360f)]
    public float rotationCam_z = 0.0f;

    public Vector3 directionCamera { get { return new Vector3(rotationCam_x, rotationCam_y, rotationCam_z); } }

    void Start()
    {
        //originalGameObject = GameObject.Find("MainObj");
        //child = originalGameObject.transform.GetChild(0).gameObject;
    }

    void OnMouseDown()
    {
        Debug.Log("coucou");
        //Destroy(child);
    }

    void Update()
    {
        
    }
}
