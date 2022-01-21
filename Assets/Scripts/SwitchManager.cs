using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    public List<CharacterTemplate> allCharacters;
    public Switch[] switches;

    private void Start()
    {
        List<string> switchList = new List<string>();
        for (int i = 0; i < allCharacters.Count; i++)
        {
            if (allCharacters[i].character == Character.axel) ;
            Debug.Log("c'est oui");
            for (int j = 0; j < allCharacters[i].dialogueChoiceBySwitches.Length; j++)
            {
                switchList.Add(allCharacters[i].dialogueChoiceBySwitches[j]._switchIDs);
            }
        }

        switches = new Switch[switchList.Count];

        for (int i = 0; i < switches.Length; i++)
        {
            switches[i].id = switchList[i];
        }
    }

    public bool CheckSwitch(string sToCheck)
    {
        foreach (var _switch in switches)
        {
            if (_switch.id == sToCheck)
            {
                Debug.Log(_switch.id + " - " + _switch.value);
                return _switch.value;
            }
        }
        return false;
    }

    public void SetSwitch(string id, bool value)
    {
        for (int i = 0; i < switches.Length; i++)
        {
            if (switches[i].id == id)
            {
                switches[i].value = value;
            }
        }
    }
}