using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFacingCamera : MonoBehaviour
{

    public Transform cameraToFace;

    void Start()
    {
        cameraToFace = FindObjectOfType<Camera>().transform;
    }


    void Update()
    {
        transform.LookAt(cameraToFace);
    }
}
