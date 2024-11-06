using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerShootSystem playerShootSystem; // R�f�rence au script de tir du joueur
    public TextMeshProUGUI countdownText; // Le texte du compte � rebours
    public GameObject gameOverPanel; // R�f�rence au panneau de fin de jeu
    public LayerMask enemyLayer; // Layer des ennemis

    private bool gameOver = false; // Indicateur pour v�rifier si le jeu est termin�

    void Start()
    {
        DisableShooting();
        gameOverPanel.SetActive(false); // D�sactiver le panneau de fin de jeu au d�but
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
        // D�sactiver les tirs du joueur
        playerShootSystem.DisableShooting();
    }

    void EnableShooting()
    {
        // Activer les tirs du joueur
        playerShootSystem.EnableShooting();
    }

    IEnumerator StartGameSequence()
    {
        // Compte � rebours
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
        DisableShooting(); // D�sactiver les tirs du joueur
        gameOver = true; // Indiquer que le jeu est termin�
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recharger la sc�ne actuelle
    }

    public void QuitGame()
    {
        Application.Quit(); // Quitter le jeu
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Arr�ter le mode de jeu dans l'�diteur
#endif
    }
}
