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
            StartCoroutine(DieEffect()); // Lancer la coroutine de l'effet de mort
        }
    }

    IEnumerator FlashWhite()
    {
        Color originalColor = meshRenderer.material.color;
        meshRenderer.material.color = Color.white; 
        yield return new WaitForSeconds(0.1f); 
        meshRenderer.material.color = originalColor; 
    }

    IEnumerator DieEffect()
    {
        float duration = 0.5f; 
        float timeElapsed = 0f;

        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale * 1.5f; 

        Color originalColor = meshRenderer.material.color;
        Color targetColor = originalColor;
        targetColor.a = 0f; 

        while (timeElapsed < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, timeElapsed / duration);
            meshRenderer.material.color = Color.Lerp(originalColor, targetColor, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
        meshRenderer.material.color = targetColor;

        Destroy(gameObject); 
    }
}
