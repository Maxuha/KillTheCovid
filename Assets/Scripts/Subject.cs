using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    [SerializeField] protected float speed = 2000f;
    [SerializeField] protected Player _player;
    protected float _speedRotation = 1800f;
    protected float _speedDestroy = 0.1f;
    protected float _currentDestroy;
    protected int sizePlus = 20;
    protected bool _isDead;
    protected Rigidbody2D _thisRigidbody;
    protected Collider2D other;
    [SerializeField] protected ParticleSystem flashDead;

    public float GetSpeed()
    {
        return speed;
    }
    
    protected void Start()
    {
        _thisRigidbody = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("Player").GetComponent<Player>();
        _thisRigidbody.AddTorque(_speedRotation * Time.deltaTime, ForceMode2D.Impulse);
    }
}
