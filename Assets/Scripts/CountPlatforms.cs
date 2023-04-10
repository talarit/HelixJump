using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountPlatforms : MonoBehaviour
{
    public Text Text;
    public Game Game;

    //считаем количество разбитых секторов   
    void Start()
    {
        Text.text = "Разбитые сектора: " + (Game.CountIndex).ToString();
    }
}
