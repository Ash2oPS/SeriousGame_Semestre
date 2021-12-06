using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    public Vector3 targetLocation;
    private Vector3 targetRotation;
    private Vector3 positionCamera = new Vector3(+3, +4, +7);
    private Transform cameraTransform { get; set; } = null;
    private float cameraSpeed = 2.0f;

    private void Start()
    {
        cameraTransform = GetComponent<Transform>();
        targetLocation = cameraTransform.transform.position;
    }

    private void Update()
    {
        DrawRay();

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.farClipPlane));

            if (Physics.Raycast(cameraTransform.position, worldPos - cameraTransform.position, out RaycastHit hit))
            {
                Debug.Log(hit.transform.name);
                targetLocation = hit.transform.position;
                CameraOnTarget CC = hit.GetComponent<CameraOnTarget>();
                if (CC)
                {
                    CameraOnTarget tog = hit.GetComponent<CameraOnTarget>();
                    Debug.Log(tog.rotationCam_x);
                }
                //////////CameraOnTarget tog = hit.GetComponent<CameraOnTarget>();
                //Debug.Log(tog.rotationCam_x);
                //Debug.Log(hit.rotationCam_x);
                //targetRotation = new Vector3(hit.rotationCam_x, hit.rotationCam_y, hit.rotationCam_z);
                Debug.Log(targetLocation);

                //cameraTransform.position = targetLocation + positionCamera;
            }
        }
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetLocation + positionCamera, cameraSpeed * Time.deltaTime);
        //Quaternion target = Quaternion.Euler(hit.)
        //cameraTransform.rotation = Vector3

    }

    private void TransitionCamera(Vector3 start, Vector3 end)
    {

    }

    private void DrawRay()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.farClipPlane));

        Debug.DrawRay(cameraTransform.position, worldPos - cameraTransform.position, Color.red);
    }
}
