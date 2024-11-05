using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Le prefab de l'ennemi
    public int rows = 3; // Nombre de lignes d'ennemis (ajusté)
    public int columns = 5; // Nombre de colonnes d'ennemis (ajusté)
    public float spacing = 1f; // Espace entre chaque ennemi (ajusté)
    public float spawnHeight = 6f; // Hauteur de spawn au-dessus du joueur
    public float playerZPosition = -5f; // Position Z fixe des ennemis

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        SpawnEnemyFormation();
    }

    void SpawnEnemyFormation()
    {
        float startX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, playerZPosition)).x;
        float endX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, playerZPosition)).x;

        float totalWidth = (columns - 1) * spacing;
        float offsetX = (endX - startX - totalWidth) / 2;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                float posX = startX + offsetX + col * spacing;
                float posY = spawnHeight - row * spacing;
                Vector3 spawnPosition = new Vector3(posX, posY, playerZPosition);
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
