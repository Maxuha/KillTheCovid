using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 200f;
    private float lifeCircle = 1.0f;
    private float _currentLife;

    public float GetSpeed()
    {
        return speed;
    }

    private void Update()
    {
        _currentLife += Time.deltaTime;

        if (_currentLife > lifeCircle)
        {
            Destroy(gameObject);
        }
    }
}
