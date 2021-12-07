using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public SpriteRenderer sr;

    public void ChangeMaterial(Material newMaterial)
    {
        sr = GetComponent<SpriteRenderer>();
        sr.material = newMaterial;
    }
}
