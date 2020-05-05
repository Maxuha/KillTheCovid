using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{ 
    private Transform player;
    private Camera mainCamera;
    private bool _isActive;

    public void setActive(bool _isActive)
    {
        this._isActive = _isActive;
    }

    void Start()
    {
        player = transform;
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (_isActive)
        {
            Vector3 playerPos = player.position;
            var mousePosition = Input.mousePosition;
            mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
            var angle = Vector2.Angle(Vector2.right, mousePosition - playerPos);
            player.eulerAngles = new Vector3(0f, 0f, playerPos.y < mousePosition.y ? angle : -angle);
            
            if (Input.GetMouseButtonUp(0) || Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                _isActive = false;
            }
        }
    }
}

