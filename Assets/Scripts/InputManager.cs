using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("Click Gauche partout");
        }
        if (Input.GetMouseButtonDown(1))
        {
            print("Click droit partout");
        }
        if (Input.GetMouseButtonDown(2))
        {
            print("Click molette partout");
        }
    }

    private void OnMouseDown()
    {
        print("Bonjour");
    }
}
