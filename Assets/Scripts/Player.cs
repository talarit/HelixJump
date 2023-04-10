using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public Platforms CurrentPlatform;
    public Game Game;
    public float _time = 0.5f;
    private bool isEnd = false;

    private void Update()
    {

        if (isEnd) Times();
    }

    void Times()
    {
        _time -= Time.deltaTime;
        if (_time <= 0) Die();
    }
    public void Bounce()
    {
        Rigidbody.velocity = new Vector3(0, BounceSpeed, 0);
    }

    public void ReachFinish()
    {
        Game.OnPlayerReachedFinish();
        Rigidbody.velocity = Vector3.zero;
    }

    public void Die()
    {
        isEnd = true;
        Rigidbody.velocity = Vector3.zero;
        if (_time < 0)
        {
            Game.OnPlayerDead();
        }
    }
}
