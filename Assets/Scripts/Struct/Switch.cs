using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Switch
{
    public string id;
    [HideInInspector]
    public bool value;
}
