using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] private Bullet bullet;
	[SerializeField] private Transform pointStartBullet;
    private Transform _thisTransform;
    [SerializeField] private float rateOfFire = 0.5f;
    private float _currentTime;

    void Start()
    {
        _thisTransform = transform;
    }

    void Update()
    {
        _currentTime += Time.deltaTime;
        
        if (_currentTime > rateOfFire) 
        {
            Rigidbody2D currentBullet = Instantiate(bullet, pointStartBullet.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            currentBullet.AddForce(_thisTransform.position * bullet.GetSpeed(), ForceMode2D.Impulse);
            _currentTime = 0;
        }
    }
}
