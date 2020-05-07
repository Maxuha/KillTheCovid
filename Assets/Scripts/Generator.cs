using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{
    [SerializeField] private Virus virus;
    [SerializeField] private Subject[] subjects;
    [SerializeField] private AnimationCurve difficulty;
    private float timeGenerateVirus = 1f;
    private float _currentTimeVirus;
    private float timeGenerateSubject = 3f;
    private float _currentTimeSubject;
    [SerializeField] private Transform player;

    void Update()
    {
        UIManager.timeGame += Time.deltaTime;
        if (UIManager.timeGame >= 75)
        {
            UIManager.timeGame = 30;
        }
        Debug.Log("Time: " + UIManager.timeGame / 60);
        timeGenerateVirus = difficulty.Evaluate(UIManager.timeGame / 60);
        CreateVirus();
        CreateLimfocit();
    }

    private void CreateVirus()
    {
        _currentTimeVirus += Time.deltaTime;
        if (_currentTimeVirus > timeGenerateVirus)
        {
            Rigidbody2D currentVirus = Instantiate(virus, GetPosition(), Quaternion.identity).GetComponent<Rigidbody2D>();
            currentVirus.AddForce(((Vector2) player.position - currentVirus.position).normalized * virus.GetSpeed(), ForceMode2D.Impulse);
            _currentTimeVirus = 0;
        }
    }

    private void CreateLimfocit()
    {
        _currentTimeSubject += Time.deltaTime;
        if (_currentTimeSubject > timeGenerateSubject)
        {
            Rigidbody2D currentSubject = Instantiate(subjects[0], GetPosition(), Quaternion.identity).GetComponent<Rigidbody2D>();
            currentSubject.AddForce(((Vector2) player.position - currentSubject.position).normalized * subjects[0].GetSpeed(), ForceMode2D.Impulse);
            _currentTimeSubject = 0;
        }
    }
    
    private Vector2 GetPosition()
    {
        float x = 0;
        float y = 0;
        int range = Random.Range(0, 3);
        switch (range)
        {
            case 0: x = -3;
                y = Random.Range(-4f, 4f);
                break;
            case 1:
                int value = Random.Range(0, 2);
                if (value == 0)
                {
                    y = 4.0f;
                }
                else
                {
                    y = -4.0f;
                }
                x = Random.Range(-3.0f, 3.0f);
                break;
            case 2: x = 3;
                y = Random.Range(-4f, 4f);
                break;
        }
        return new Vector2(x, y);
    }
}
