using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int rows = 3;
    public int columns = 5;
    public float spacing = 1f;
    public float spawnHeight = 6f;
    public float playerZPosition = -5f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found");
            return;
        }

        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy Prefab not assigned");
            return;
        }

        SpawnEnemyFormation();
    }

    public void SpawnEnemyFormation()
    {
        Debug.Log("Starting SpawnEnemyFormation");

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
                Debug.Log("Spawned enemy at: " + spawnPosition);
            }
        }
    }
}
