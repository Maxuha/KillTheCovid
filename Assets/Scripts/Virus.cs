using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Virus : Subject
{
    private SpriteRenderer _thisSprite;
    
    public float GetSpeed()
    {
        return speed;
    }

    private void Start()
    {
        base.Start();
        _thisSprite = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (_isDead)
        {
            _currentDestroy += Time.deltaTime;
            if (_currentDestroy >= _speedDestroy)
            {
                _player.AddScore();
                if (other != null)
                {
                    Destroy(other.gameObject);
                }

                Destroy(gameObject);
                _currentDestroy = 0;
            }
            else
            {
                _thisSprite.color = Color32.LerpUnclamped(_thisSprite.color,  Color.red, _speedDestroy);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ("Bullet".Equals(other.tag))
        {
            //flashDead.Play();
            this.other = other;
            _isDead = true;
        } 
        else if ("Player".Equals(other.tag))
        {
            SceneManager.LoadScene(0);
        }
    }
}
