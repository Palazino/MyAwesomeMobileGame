using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerShootSystem playerShootSystem; // R�f�rence au script de tir du joueur
    public TextMeshProUGUI countdownText; // Le texte du compte � rebours

    void Start()
    {
        DisableShooting();
        StartCoroutine(StartGameSequence());
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
}
