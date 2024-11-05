using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float amplitude = 0.5f; // Amplitude du mouvement sinuso�dal
    public float frequency = 1f; // Fr�quence du mouvement sinuso�dal
    private Vector3 startPosition;
    private float randomOffset;

    void Start()
    {
        startPosition = transform.position; // Enregistrer la position de d�part
        randomOffset = Random.Range(0f, 2 * Mathf.PI); // G�n�rer un d�calage al�atoire
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
