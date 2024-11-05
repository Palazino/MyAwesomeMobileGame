using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 1; // Dégâts infligés par le projectile

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Projectile collided with: " + other.name); // Log pour vérifier la collision

        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage); // Infliger des dégâts à l'ennemi
            Destroy(gameObject); // Détruire le projectile
            Debug.Log("Enemy took damage and projectile destroyed"); // Log pour confirmer
        }
    }
}
