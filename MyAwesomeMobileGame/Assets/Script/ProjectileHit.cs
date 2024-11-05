using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 1; // D�g�ts inflig�s par le projectile

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Projectile collided with: " + other.name); // Log pour v�rifier la collision

        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage); // Infliger des d�g�ts � l'ennemi
            Destroy(gameObject); // D�truire le projectile
            Debug.Log("Enemy took damage and projectile destroyed"); // Log pour confirmer
        }
    }
}
