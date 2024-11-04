using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePoolSystem : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private int _nbOfProjectileInPool = 10;
    void Start()
    {
        for (var i = 0; i < _nbOfProjectileInPool; i++)
        {
            var instance = Instantiate(_projectilePrefab, transform);
            instance.SetActive(false);
        }
    }

    public GameObject GetFirstProjectileAvailable()
    {
        foreach (Transform child in transform)
        { 
            if(child.gameObject.activeSelf == false)
            {
                return child.gameObject;
            }
        }
        var instance = Instantiate(_projectilePrefab, transform);
        instance.SetActive(true);
        return instance;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
