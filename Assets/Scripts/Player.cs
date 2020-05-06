using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Image bonusSlider;
    private int _score;
    [SerializeField] private Text text;
    private float _currentPlus;
    [SerializeField] private BonusManager bonusManager;
    private Transform _thisTransform;
    private Transform _bonusSliderPos;

    private void Start()
    {
        text = GameObject.Find("Score").GetComponent<Text>();
        _bonusSliderPos = bonusSlider.transform;
        _thisTransform = transform;
    }

    private void Update()
    {
        _bonusSliderPos.rotation = _thisTransform.rotation;
        
        if (bonusManager.IsActiveBonus)
        {
            AddBonus(0);
            bonusManager.SetActiveBonus(false);
        }
    }

    public void AddBonus(int sizePlus)
    {
        _currentPlus += (float) sizePlus / 100;
        bonusSlider.fillAmount = _currentPlus;
        if (_currentPlus >= 1)
        {
            bonusManager.SelectBonus();
            _currentPlus = 0;
        }
    }

    public void AddScore()
    {
        _score++;
        text.text = "Score: " + _score;
    }
}
