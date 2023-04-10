using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Player Player;
    public Transform TransformFinish;
    public Slider Slider;
    private float _startY;
    private float _minY;
    public float FinishDist =1f;

    private void Start()
    {
        _startY = Player.transform.position.y;
    }

    private void Update()
    {
        _minY = Mathf.Min(_minY, Player.transform.position.y);
        float _finishY = TransformFinish.transform.position.y;
        float t = Mathf.InverseLerp(_startY, _finishY+FinishDist,_minY);
        Slider.value = t;
    }
}
