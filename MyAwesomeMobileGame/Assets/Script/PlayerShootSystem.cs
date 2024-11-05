using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootSystem : MonoBehaviour
{
    [SerializeField] private ProjectilePoolSystem _projectilePoolSystem;
    public float shootInterval = 0.5f; 

    void Start()
    {
        if (_projectilePoolSystem == null)
        {
            Debug.LogError("ProjectilePoolSystem is not assigned.");
        }
        else
        {
            Debug.Log("ProjectilePoolSystem is assigned");
        }

        // Commence à tirer continuellement
        InvokeRepeating("ShootProjectile", 0f, shootInterval);
    }

    void ShootProjectile()
    {
        var projectile = _projectilePoolSystem.GetFirstProjectileAvailable();
        if (projectile != null)
        {
            projectile.transform.position = transform.position;
            Debug.Log("Projectile fired");
        }
        else
        {
            Debug.LogWarning("No projectile available in pool");
        }
    }
}
