using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifetime : MonoBehaviour
{
    [SerializeField] private float _lifetime = 3f;
    private float _timer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _timer = _timer + Time.deltaTime;
        if (_timer > _lifetime)
        {
            gameObject.SetActive(false);
        }


    }

    private void OnEnable()
    {
        _timer = 0;
    }
}
;