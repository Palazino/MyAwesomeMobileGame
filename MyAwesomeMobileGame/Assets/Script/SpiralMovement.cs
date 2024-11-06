using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMovement : MonoBehaviour
{
    public float speed = 1f; 
    public float frequency = 1f; 
    public float amplitude = 1f; 
    private Vector3 startPosition;
    private float timeOffset;

    void Start()
    {
        startPosition = transform.position; 
        timeOffset = Random.Range(0f, 2 * Mathf.PI); 
    }

    void Update()
    {
        MoveInSpiral();
    }

    void MoveInSpiral()
    {
        float x = amplitude * Mathf.Cos(Time.time * frequency + timeOffset);
        float y = amplitude * Mathf.Sin(Time.time * frequency + timeOffset);
        transform.position = startPosition + new Vector3(x, y, 0) * Time.deltaTime * speed;
    }
}
