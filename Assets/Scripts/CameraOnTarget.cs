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
    public Vector3 positionCamera = new Vector3(+3, +4, +7);
    public AnimationCurve cameraSpeedCurve;
    public float cameraSpeed;
    private bool isLerping;
    private float t;
    private Quaternion rotOrigin;
    private Vector3 posOrigin;

    public Vector3 directionCamera { get { return new Vector3(rotationCam_x, rotationCam_y, rotationCam_z); } }

    public void SetCameraOnTarget()
    {
        t = 0;
        rotOrigin = Camera.main.transform.rotation;
        posOrigin = Camera.main.transform.position;
        isLerping = true;
        //Camera.main.transform.rotation = Quaternion.Euler(rotationCam_x, rotationCam_y, rotationCam_z);
    }

    public void Update()
    {
        if(isLerping)
        {
            t += cameraSpeedCurve.Evaluate(t) * cameraSpeed * Time.deltaTime;
            Camera.main.transform.position = Vector3.Lerp(posOrigin, transform.position + positionCamera, t);
            Camera.main.transform.rotation = Quaternion.Lerp(rotOrigin, Quaternion.Euler(rotationCam_x,rotationCam_y,rotationCam_z), t);
            //Camera.main.transform.LookAt(transform);

            if (t>=1)
            {
                isLerping = false;
            }
        }
    }
}
