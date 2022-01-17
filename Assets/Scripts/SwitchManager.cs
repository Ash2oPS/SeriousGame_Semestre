using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{

    public Switch[] switches;
    public bool CheckSwitch(string sToCheck)
    {
        foreach (var _switch in switches)
        {
            if(_switch.id == sToCheck)
            {
                return _switch.value;
            }
        }
        return false;
    }

    public void SetSwitch(string id, bool value)
    {
        for (int i = 0; i < switches.Length; i++)
        {
            if(switches[i].id == id)
            {
                switches[i].value = value;
            }
        }
    }
}
