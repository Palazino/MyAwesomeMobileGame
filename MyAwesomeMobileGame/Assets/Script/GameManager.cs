using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerShootSystem playerShootSystem; // Référence au script de tir du joueur
    public TextMeshProUGUI countdownText; // Le texte du compte à rebours
    public GameObject gameOverPanel; // Référence au panneau de fin de jeu
    public LayerMask enemyLayer; // Layer des ennemis

    private bool gameOver = false; // Indicateur pour vérifier si le jeu est terminé

    void Start()
    {
        DisableShooting();
        gameOverPanel.SetActive(false); // Désactiver le panneau de fin de jeu au début
        StartCoroutine(StartGameSequence());
    }

    void Update()
    {
        if (!gameOver)
        {
            CheckGameOver();
        }
    }

    void DisableShooting()
    {
        // Désactiver les tirs du joueur
        playerShootSystem.DisableShooting();
    }

    void EnableShooting()
    {
        // Activer les tirs du joueur
        playerShootSystem.EnableShooting();
    }

    IEnumerator StartGameSequence()
    {
        // Compte à rebours
        countdownText.gameObject.SetActive(true);
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        countdownText.text = "GO!";
        yield return new WaitForSeconds(1);
        countdownText.gameObject.SetActive(false);

        EnableShooting();
    }

    void CheckGameOver()
    {
        bool enemyExists = false;
        foreach (var t in FindObjectsOfType<Transform>())
        {
            if (((1 << t.gameObject.layer) & enemyLayer) != 0)
            {
                enemyExists = true;
                break;
            }
        }

        if (!enemyExists)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameOverPanel.SetActive(true); // Activer le panneau de fin de jeu
        DisableShooting(); // Désactiver les tirs du joueur
        gameOver = true; // Indiquer que le jeu est terminé
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recharger la scène actuelle
    }

    public void QuitGame()
    {
        Application.Quit(); // Quitter le jeu
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Arrêter le mode de jeu dans l'éditeur
#endif
    }
}
