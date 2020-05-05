using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBonus : Bonus
{
    private ParticleSystem ps;
    private Player _player;

    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnParticleCollision(GameObject other)
    {
        _player.AddScore();
        Destroy(other);
    }
    
    public override void InActive()
    {
        ps.Play();
    }
}
