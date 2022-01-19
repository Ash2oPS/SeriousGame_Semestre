using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BlurManager : MonoBehaviour
{
    public float speed;
    private DialogueManager dm;
    private VolumeProfile vp;
    private DepthOfField dof;
    private float t;
    private bool isUp;

    private void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
        vp = GetComponent<Volume>().profile;
        vp.TryGet<DepthOfField>(out dof);
    }

    private void Update()
    {
        if (dm.talkingCharacter == Character.none && isUp)
        {
            if (t < 1)
            {
                t += Time.deltaTime * speed / 10;
                dof.focusDistance.value = Mathf.Lerp(0.8f, 3, t);
            }
            else
            {
                t = 0;
                isUp = false;
            }
        }
        else if (dm.talkingCharacter != Character.none && !isUp)
        {
            if (t < 1)
            {
                t += Time.deltaTime * speed / 10;
                dof.focusDistance.value = Mathf.Lerp(3, 0.8f, t);
            }
            else
            {
                t = 0;
                isUp = true;
            }
        }
    }
}