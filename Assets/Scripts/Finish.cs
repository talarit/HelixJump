using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private AudioSource _audio;
    public GameObject Wins1;
    public float _time = 2f;
    private bool isEnd = false;
    public Player player1;
    private void Update()
    {

        if (isEnd) Times();
    }

    void Times()
    {
        //задержка для показа системы частиц
        _time -= Time.deltaTime;
        if (_time <= 0) player1.ReachFinish();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;
        isEnd = true;
        //звук прохождения уровня
        _audio = GetComponent<AudioSource>();
        _audio.Play();
        //система частиц выигрыша
        Wins1.GetComponent<ParticleSystem>().Play();
    }
}
