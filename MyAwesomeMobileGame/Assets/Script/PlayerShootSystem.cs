using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootSystem : MonoBehaviour
{
    [SerializeField] private ProjectilePoolSystem _projectilePoolSystem;
    public float shootInterval = 0.5f;
    private bool canShoot = false;

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

        // Commence à tirer continuellement mais seulement si canShoot est vrai
        InvokeRepeating("TryShootProjectile", 0f, shootInterval);
    }

    void TryShootProjectile()
    {
        if (canShoot)
        {
            ShootProjectile();
        }
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

    public void EnableShooting()
    {
        canShoot = true;
    }

    public void DisableShooting()
    {
        canShoot = false;
    }
}
