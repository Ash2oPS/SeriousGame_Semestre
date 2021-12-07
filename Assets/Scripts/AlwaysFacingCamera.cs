using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFacingCamera : MonoBehaviour
{

    private Transform cameraToFace;

    void Start()
    {
        cameraToFace = FindObjectOfType<Camera>().transform;
        GetComponent<SpriteRenderer>().flipX = true;
    }


    void Update()
    {
        transform.LookAt(cameraToFace);
    }
}
