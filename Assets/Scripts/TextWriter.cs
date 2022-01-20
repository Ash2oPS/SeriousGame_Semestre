using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWriter : MonoBehaviour
{
    public bool isWriting;

    [SerializeField]
    private float speed = 10;

    private float timeToWait = 0;
    private bool hasToStop = false;
    private DialogueManager dm;

    public IEnumerator Write(string replique, TextMeshProUGUI tmp1, TextMeshProUGUI tmp2)
    {
        float baseSpeed = speed;
        string ceQuiEstEcrit = "";
        for (int i = 0; i < replique.Length; i++)
        {
            if (hasToStop)
            {
                yield break;

                replique = WaitChecker(replique, i);
                ceQuiEstEcrit += replique[i];
                tmp1.text = ceQuiEstEcrit;
                tmp2.text = ceQuiEstEcrit;

                speed = baseSpeed;
                timeToWait = 0;
            }
            else
            {
                replique = WaitChecker(replique, i);
                ceQuiEstEcrit += replique[i];
                tmp1.text = ceQuiEstEcrit;
                tmp2.text = ceQuiEstEcrit;

                if (timeToWait == 0)
                {
                    yield return new WaitForSeconds(1 / speed);
                }
                else
                {
                    yield return new WaitForSeconds(timeToWait);
                }

                speed = baseSpeed;
                timeToWait = 0;
            }
        }
        isWriting = false;
    }

    private string WaitChecker(string replique, int index)
    {
        char caractereToCheck = replique[index];
        string stringToRemove = "#";
        string timeToWaitString = "";

        if (replique[index] == '#')
        {
            bool found = false;
            for (int i = index + 1; found == false; i++)
            {
                if (replique[i] == '#')
                {
                    found = true;
                    for (int j = index + 1; j < i; j++)
                    {
                        stringToRemove += replique[j];
                        timeToWaitString += replique[j];
                    }
                }
            }
            Debug.Log(timeToWaitString);
            timeToWait = float.Parse(timeToWaitString);
            stringToRemove += '#';
            replique = replique.Replace(stringToRemove, "");
        }

        return replique;
    }

    public void EndWait()
    {
        if (isWriting)
        {
            hasToStop = true;
        }
    }
}