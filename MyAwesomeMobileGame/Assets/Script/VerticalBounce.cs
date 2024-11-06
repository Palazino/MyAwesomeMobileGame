using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBounce : MonoBehaviour
{
    public float amplitude = 0.5f; // Amplitude du mouvement (distance)
    public float frequency = 1f; // Fr�quence du mouvement (vitesse)

    private Vector3 startPosition;

    void Start()
    {
        // Enregistrer la position initiale de l'objet
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculer le d�calage de la position en utilisant une fonction sinuso�dale
        float yOffset = amplitude * Mathf.Sin(Time.time * frequency);
        // Mettre � jour la position de l'objet
        transform.position = new Vector3(startPosition.x, startPosition.y + yOffset, startPosition.z);
    }
}
