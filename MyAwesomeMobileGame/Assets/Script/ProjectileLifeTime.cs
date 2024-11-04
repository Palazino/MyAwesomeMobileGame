using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifeTime : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 3f;
    private float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > _lifeTime)
        {
            gameObject.SetActive(false);

        }
    }
    private void OnEnable()
    {
        timer = 0;
    }
}
