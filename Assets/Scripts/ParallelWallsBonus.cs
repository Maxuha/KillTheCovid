using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ParallelWallsBonus : Bonus
{
    [SerializeField] private GameObject wallVertical;
    [SerializeField] private GameObject wallHorizontal;
    private int random;
    private GameObject[] walls;
    private float lifeTime;
    private float maxLifeTime = 15.0f;
    private Vector2 left, right, up, down;
    private Quaternion quaternion;

    private void Start()
    {
        walls = new GameObject[2];
        left = new Vector2(-2, 0);
        right = new Vector2(2, 0);
        up = new Vector2(0, 3.05f);
        down = new Vector2(0, -3.05f);
    }

    private void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime >= maxLifeTime)
        {
            InDisActive();
            lifeTime = 0;
        }
    }

    public override void InActive()
    {
        random = Random.Range(0, 2);
        if (random == 0)
        {
            quaternion = wallVertical.transform.rotation;
            walls[0] = Instantiate(wallVertical, left, quaternion);
            walls[1] = Instantiate(wallVertical, right, quaternion);
        }
        else
        {
            quaternion = wallHorizontal.transform.rotation;
            walls[0] = Instantiate(wallHorizontal, up, quaternion);
            walls[1] = Instantiate(wallHorizontal, down, quaternion);
        }
    }

    void InDisActive()
    {
        Destroy(walls[0]);
        Destroy(walls[1]);

    }
}
