using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFacingCamera : MonoBehaviour
{
    private Transform cameraToFace;

    private void Start()
    {
        cameraToFace = FindObjectOfType<Camera>().transform;
        GetComponent<SpriteRenderer>().flipX = true;
    }

    private void Update()
    {
        //transform.LookAt(cameraToFace);

        Vector3 difference = cameraToFace.position - transform.position;
        float rotationY = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, rotationY, 0.0f);
    }
}