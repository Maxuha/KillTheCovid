using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimfocitSubject : Subject
{
    private bool _isBonus;
    
    public void Update()
    {
        if (_isDead)
        {
            _currentDestroy += Time.deltaTime;
            if (_currentDestroy > _speedDestroy)
            {
                if (_isBonus)
                {
                    _player.AddBonus(sizePlus);
                }
                
                Destroy(gameObject);
                _currentDestroy = 0;
            }
            else
            {
                //_thisSprite.color = Color32.LerpUnclamped(_thisSprite.color,  Color.red, _speedDestroy);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        this.other = other;
        _isDead = true;
        if ("Player".Equals(other.tag))
        {
            _isBonus = true;
        }
    }
}
