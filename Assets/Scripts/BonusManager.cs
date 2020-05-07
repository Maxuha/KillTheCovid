using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BonusManager : MonoBehaviour
{
    [SerializeField] private Bonus[] bonuses;
    [SerializeField] private ParticleSystem pressMe;
    private Bonus _currentBonus;
    private float _timeClick;
    private float maxTimeClick = 2.0f;
    private bool _isClick;
    private bool _isTwoClick;
    private bool _isActiveBonus;
    

    public void SelectBonus()
    {
        int random = Random.Range(0, bonuses.Length);
        _currentBonus = bonuses[random];
        pressMe.Play();
    }

    public bool IsActiveBonus => _isActiveBonus;

    public void SetActiveBonus(bool _isActiveBonus)
    {
        this._isActiveBonus = _isActiveBonus;
    }

    public Bonus GetCurrentBonus()
    {
        return _currentBonus;
    }
    
    public void Update()
    {
        if (_isTwoClick)
        {
            if (_currentBonus != null)
            {
                pressMe.Stop();
                _currentBonus.InActive();
                _isActiveBonus = true;
                _currentBonus = null;
            }
            _isClick = false;
            _isTwoClick = false;
        }

        if (_isClick)
        {
            TwoClick();
        }
        else
        {
            OneClick();
        }
    }

    private void OneClick()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.transform.position, Input.mousePosition);
            if ("Player".Equals(hit2D.transform.tag))
            {
                hit2D.transform.GetComponent<Controller>().setActive(true);
                _isClick = true;
            }
        }
    }

    private void TwoClick()
    {
        _timeClick += Time.deltaTime;
        
        if (_timeClick <= maxTimeClick)
        {
            if (Input.GetMouseButtonDown(0) || Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                _isTwoClick = true;
                _timeClick = 0;
            }
        }
        else
        {
            _isClick = false;
            _timeClick = 0;
        }
    }
}
