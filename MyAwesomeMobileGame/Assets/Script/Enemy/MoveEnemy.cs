using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float amplitude = 0.5f; // Amplitude du mouvement sinusoïdal
    public float frequency = 1f; // Fréquence du mouvement sinusoïdal
    private Vector3 startPosition;
    private float randomOffset;

    void Start()
    {
        startPosition = transform.position; // Enregistrer la position de départ
        randomOffset = Random.Range(0f, 2 * Mathf.PI); // Générer un décalage aléatoire
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
