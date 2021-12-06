using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnTarget : MonoBehaviour
{
    
    private GameObject originalGameObject = GameObject.Find("MainObj");
    public GameObject child = null;

    private void Start()
    {
        child = originalGameObject.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        
    }
}
