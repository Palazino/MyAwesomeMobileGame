using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMovement : MonoBehaviour
{
    public float speed = 1f; // Vitesse du mouvement
    public float frequency = 1f; // Fréquence du mouvement en spirale
    public float amplitude = 1f; // Amplitude du mouvement en spirale
    private Vector3 startPosition;
    private float timeOffset;

    void Start()
    {
        startPosition = transform.position; // Enregistrer la position de départ
        timeOffset = Random.Range(0f, 2 * Mathf.PI); // Générer un décalage aléatoire pour chaque ennemi
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
