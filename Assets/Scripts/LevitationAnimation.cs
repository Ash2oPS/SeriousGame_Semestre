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

    private void Start()
    {
        tf = transform;
        dm = FindObjectOfType<DialogueManager>();
        baseX = tf.position.x;
        baseY = tf.position.y;
        baseZ = tf.position.z;
    }

    private void Update()
    {
        if (dm.talkingCharacter == Character.none)
        {
            newY = baseY + Mathf.Sin(timer * frequency) * amplitude;

            if (gameObject.layer == 5)
            {
                RectTransform rt = GetComponent<RectTransform>();

                rt.position = new Vector3(baseX, newY, baseZ);
            }
            else
            {
                tf.position = new Vector3(baseX, newY, baseZ);
            }

            timer += Time.deltaTime;
        }
    }
}