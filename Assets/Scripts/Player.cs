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
    private int _record;
    private int _maxRecord;
    [SerializeField] private Text scoreText, recordText;
    private float _currentPlus;
    [SerializeField] private BonusManager bonusManager;
    private Transform _thisTransform;
    private Transform _bonusSliderPos;

    private void Start()
    {
        ApplyRecord();
        recordText.text = "High Score: " + _maxRecord;
        scoreText = GameObject.Find("Score").GetComponent<Text>();
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
        if (_record > 0 && _record < _maxRecord)
            _record--;
        else
            _record++;

        if (_score > _maxRecord)
            _maxRecord = _score;
        
        scoreText.text = "Score: " + _score;
        recordText.text = "High Score: " + _record;
    }

    private void ApplyRecord()
    {
        _maxRecord = SaveManager.Load();
    }

    public void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
            SaveManager.Save(_maxRecord);
    }

    public void OnApplicationQuit()
    {
        SaveManager.Save(_maxRecord);
    }
}
