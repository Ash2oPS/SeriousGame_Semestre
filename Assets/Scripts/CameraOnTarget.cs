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
    private float cameraSpeedTranslation = 0.6f;
    private float cameraSpeedRotation = 0.6f;
    private bool isLerpingTranslation;
    private bool isLerpingRotation;
    private float t_Translation;
    private float t_Rotation;
    private Quaternion rotOrigin;
    private Quaternion rotFinal;
    private Vector3 posOrigin;
    private Vector3 posFinal;

    public Vector3 directionCamera { get { return new Vector3(rotationCam_x, rotationCam_y, rotationCam_z); } }

    public void SetCameraOnTarget()
    {
        t_Translation = 0;
        t_Rotation = 0;
        rotOrigin = Camera.main.transform.rotation;
        rotFinal = Quaternion.Euler(rotationCam_x,rotationCam_y,rotationCam_z);
        posOrigin = Camera.main.transform.position;
        posFinal = transform.position  - Quaternion.Euler(rotationCam_x,rotationCam_y,rotationCam_z) * Vector3.forward * 10.0f;
        isLerpingTranslation = true;
        isLerpingRotation = true;
        //Camera.main.transform.rotation = Quaternion.Euler(rotationCam_x, rotationCam_y, rotationCam_z);
    }

    public void Update()
    {
        if(isLerpingTranslation)
        {
            t_Translation += cameraSpeedCurve.Evaluate(t_Translation) * cameraSpeedTranslation * Time.deltaTime;
            Camera.main.transform.position = Vector3.Lerp(posOrigin, posFinal, t_Translation);
            if (t_Translation>=1)
            {
                isLerpingTranslation = false;
            }
        }
        if(isLerpingRotation)
        {
            t_Rotation += cameraSpeedCurve.Evaluate(t_Rotation) * cameraSpeedRotation * Time.deltaTime;
            Camera.main.transform.rotation = Quaternion.Lerp(rotOrigin, rotFinal, t_Rotation);
            if (t_Rotation>=1)
            {
                isLerpingRotation = false;
            }
        }
    }
}
