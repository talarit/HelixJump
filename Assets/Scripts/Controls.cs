using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    private Vector3 _previewposition;
    public Transform Level;
    public float Sensitivity;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previewposition;
            Level.Rotate(0, -delta.x*Sensitivity,0);
        }
        _previewposition = Input.mousePosition;
    }
}
