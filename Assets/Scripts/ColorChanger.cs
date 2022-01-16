using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public SpriteRenderer sr;

    public void ChangeColor(int newColor)
    {
        sr = GetComponent<SpriteRenderer>();
        if (newColor == 0)
        {
            sr.color = Color.white;
        }
        else if (newColor == 1)
        {
            sr.color = Color.yellow;
        }
    }
}