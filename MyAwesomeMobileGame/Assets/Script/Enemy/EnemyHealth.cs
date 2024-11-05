using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3; // Points de vie maximum
    private int currentHealth;
    private MeshRenderer meshRenderer; // Référence au MeshRenderer

    void Start()
    {
        currentHealth = maxHealth; // Initialiser les points de vie
        meshRenderer = GetComponent<MeshRenderer>(); // Obtenir la référence au MeshRenderer

        if (meshRenderer == null)
        {
            Debug.LogError("MeshRenderer not found on " + gameObject.name);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Réduire les points de vie
        if (meshRenderer != null)
        {
            StartCoroutine(FlashWhite()); // Lancer la coroutine de clignotement
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Logique de destruction, animation, effets, etc.
        Destroy(gameObject); // Détruire l'ennemi
    }

    IEnumerator FlashWhite()
    {
        Color originalColor = meshRenderer.material.color;
        meshRenderer.material.color = Color.white; // Changer la couleur en blanc
        yield return new WaitForSeconds(0.1f); // Attendre un court instant
        meshRenderer.material.color = originalColor; // Restaurer la couleur originale
    }
}
