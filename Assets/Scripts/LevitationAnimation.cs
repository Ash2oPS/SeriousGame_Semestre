using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitationAnimation : MonoBehaviour
{
    private Transform tf;
    private DialogueManager dm;
    public float timer = 0f;
    public float baseX = 0f;
    public float baseY = 0f;
    public float baseZ = 0f;
    private float newY = 0f;
    public float frequency = 3f;
    public float amplitude = 0.1f;

    public bool applyToLocal;

    private void Start()
    {
        tf = transform;
        dm = FindObjectOfType<DialogueManager>();
        if (!applyToLocal)
        {
            baseX = tf.position.x;
            baseY = tf.position.y;
            baseZ = tf.position.z;
        }
        else
        {
            baseX = tf.localPosition.x;
            baseY = tf.localPosition.y;
            baseZ = tf.localPosition.z;
        }
    }

    private void Update()
    {
        if (!dm.isDialogueOn)
        {
            newY = baseY + Mathf.Sin(timer * frequency) * amplitude;

            if (gameObject.layer == 5)
            {
                RectTransform rt = GetComponent<RectTransform>();

                rt.position = new Vector3(baseX, newY, baseZ);
            }
            else
            {
                if (!applyToLocal)
                {
                    tf.position = new Vector3(baseX, newY, baseZ);
                }
                else
                {
                    tf.localPosition = new Vector3(baseX, newY, baseZ);
                }
            }

            timer += Time.deltaTime;
        }
    }
}