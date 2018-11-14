using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragInput : MonoBehaviour
{
    public float Sensivity = 0.01f;
    private Vector3 _lastPos;
    private bool _touchDown;
    private void Update()
    {
        if (!_touchDown)
            _lastPos = Input.mousePosition;
        if (Input.GetMouseButton(0))
        {
            _touchDown = true;
            transform.position += (Input.mousePosition - _lastPos) * Sensivity;
        }
        else
        {
            _touchDown = false;
        }
        _lastPos = Input.mousePosition;
    }
}
