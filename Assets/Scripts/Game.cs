using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private AudioSource _audio;
    private void Awake()
    {
        //фоновая музыка
        _audio = GetComponent<AudioSource>();
        _audio.Play();
    }
    public Controls Controls;
   public enum State
    {
        Playing,
        Win,
        Lose
    }

    public State CurrentState { get; private set; }

    public void OnPlayerDead()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Lose;
        Controls.enabled = false;
        Debug.Log("Game over");
        Reload();
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Win;
        LevelIndex++;
        Controls.enabled = false;
        Debug.Log("Player Win");
        Reload();
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);

        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }

    }

    public int CountIndex
    {
        get => PlayerPrefs.GetInt(CountIndexKey, 0);

         set
        {
            PlayerPrefs.SetInt(CountIndexKey, value);
            PlayerPrefs.Save();
        }

    }

    private const string LevelIndexKey = "LevelIndex";
    private const string CountIndexKey = "CountIndex";
    private void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
