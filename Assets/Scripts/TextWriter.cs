using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWriter : MonoBehaviour
{
    public float timeBetweenChars;
    public string replique, ceQuiEstEcrit;
    public bool isWriting;

    private int currentIndex;
    private float timeToWait, timer, baseSpeed;
    private bool hasToStop = false;
    private DialogueManager dm;
    private TextMeshProUGUI tmp1, tmp2;

    private void Start()
    {
        baseSpeed = timeBetweenChars;
        currentIndex = 0;
    }

    public void Update()
    {
        if (isWriting)
        {
            if (!hasToStop)
            {
                if (timer >= timeBetweenChars && currentIndex < replique.Length)
                {
                    timeToWait = 0;
                    timer = 0;
                    timeBetweenChars = baseSpeed;
                    replique = WaitChecker(replique, currentIndex);
                    ceQuiEstEcrit += replique[currentIndex];
                    tmp1.text = ceQuiEstEcrit;
                    tmp2.text = ceQuiEstEcrit;
                    currentIndex++;
                }
                else if (timer < timeBetweenChars)
                {
                    timer += Time.deltaTime;
                }
                else if (currentIndex >= replique.Length)
                {
                    isWriting = false;
                }
            }
            else
            {
                timeToWait = 0;
                timer = 0;
                timeBetweenChars = baseSpeed;
                for (int i = 0; i < replique.Length; i++)
                {
                    if (replique[i] == '#')
                    {
                        replique = WaitChecker(replique, i);
                    }
                }
                tmp1.text = replique;
                tmp2.text = replique;
                isWriting = false;
                hasToStop = false;
                ceQuiEstEcrit = "";
                timeBetweenChars = baseSpeed;
                timer = 0;
                currentIndex = 0;
            }
        }
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
            timeToWait = float.Parse(timeToWaitString);
            timeBetweenChars = timeToWait;
            stringToRemove += '#';
            replique = replique.Replace(stringToRemove, "");
        }

        return replique;
    }

    public void StartWriting(string rep, TextMeshProUGUI tmpugui1, TextMeshProUGUI tmpugui2)
    {
        replique = rep;
        tmp1 = tmpugui1;
        tmp2 = tmpugui2;
        ceQuiEstEcrit = "";
        timeBetweenChars = baseSpeed;
        isWriting = true;
        timer = 0;
        currentIndex = 0;
    }

    public void EndWait()
    {
        if (isWriting)
        {
            hasToStop = true;
        }
    }
}