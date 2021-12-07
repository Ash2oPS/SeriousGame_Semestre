using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitationAnimation : MonoBehaviour
{

    private Transform tf;
    private float timer = 0f;
    private float baseX = 0f;
    private float baseY = 0f;
    private float baseZ = 0f;
    private float newY = 0f;
    public float frequency = 3f;
    public float amplitude = 0.1f;
    
    void Start()
    {
        tf = transform;
        baseX = tf.position.x;
        baseY = tf.position.y;
        baseZ = tf.position.z;
    }


    void Update()
    {
        newY = baseY + Mathf.Sin(timer * frequency) * amplitude;


        tf.position = new Vector3(baseX, newY, baseZ);

        timer += Time.deltaTime;
    }
}
