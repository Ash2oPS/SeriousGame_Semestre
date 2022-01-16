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

    private void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
        vp = GetComponent<Volume>().profile;
        vp.TryGet<DepthOfField>(out dof);
    }

    private void Update()
    {
        if (dm.talkingCharacter == Character.none && dof.focusDistance.value <= 3)
        {
            dof.focusDistance.value = Mathf.Lerp(0.8f, 3, t);
        }
        else if (dm.talkingCharacter != Character.none && dof.focusDistance.value >= 0.8)
        {
            dof.focusDistance.value = Mathf.Lerp(3, 0.8f, t);
        }

        if (t < 1)
        {
            t += Time.deltaTime * speed / 10;
        }
        else
        {
            t = 0;
        }
    }
}