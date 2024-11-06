using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float amplitude = 0.5f; 
    public float frequency = 1f; 
    private Vector3 startPosition;
    private float randomOffset;

    void Start()
    {
        startPosition = transform.position; 
        randomOffset = Random.Range(0f, 2 * Mathf.PI); 
    }

    void Update()
    {
        MoveInSinusoid();
    }

    void MoveInSinusoid()
    {
        float yOffset = amplitude * Mathf.Sin(Time.time * frequency + randomOffset);
        transform.position = new Vector3(startPosition.x, startPosition.y + yOffset, startPosition.z);
    }
}
