using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureInput : MonoBehaviour
{
    private Vector3 _firstFingerInitialPosition;
    private Vector3 _firstFingerLastPosition;
    private Vector3 _secondFingerInitialPosition;
    private Vector3 _secondFingerLastPosition;
    private bool _touchDown;
    private bool _mouse;
    private bool _singleFingerGesture;
    private void Update()
    {
        if (Input.touchCount == 1)
        {
            if (!_touchDown)
            {
                _singleFingerGesture = true;
                _touchDown = true;
                _mouse = false;
                _firstFingerInitialPosition = Input.GetTouch(0).position;
            }
            if (!_singleFingerGesture)
                return;
            _firstFingerLastPosition = Input.GetTouch(0).position;
        }
        else if (_singleFingerGesture)
        {
            if (_touchDown && Input.touchCount == 0)
            {
                ComputeSingleFingerGesture();
            }
            _touchDown = false;
        }

        if (Input.touchCount == 2)
        {
            _singleFingerGesture = false;
            if (!_touchDown)
            {
                _touchDown = true;
                _firstFingerInitialPosition = Input.GetTouch(0).position;
                _secondFingerInitialPosition = Input.GetTouch(1).position;
            }
            _firstFingerLastPosition = Input.GetTouch(0).position;
            _secondFingerLastPosition = Input.GetTouch(1).position;
        }
        else if (!_singleFingerGesture)
        {
            if (_touchDown && Input.touchCount == 0)
            {
                ComputeDoubleFingerGesture();
            }
            _touchDown = false;
        }
    }

    private void ComputeSingleFingerGesture()
    {
        Vector3 normalized = (_firstFingerLastPosition - _firstFingerInitialPosition) / (_firstFingerLastPosition - _firstFingerInitialPosition).magnitude;
        Debug.Log(normalized);
        if (normalized.x >= 0.85)
            RightSwipe();
        else if (normalized.y >= 0.85)
            DownSwipe();
        else if (normalized.x <= -0.85)
            LeftSwipe();
        else if (normalized.y <= -0.85)
            UpSwipe();
    }

    private void ComputeDoubleFingerGesture()
    {
        float initialMagnitude = (_firstFingerInitialPosition - _secondFingerInitialPosition).magnitude;
        float finalMagnitude = (_firstFingerLastPosition - _secondFingerLastPosition).magnitude;
        Debug.Log(initialMagnitude - finalMagnitude);
        if (initialMagnitude - finalMagnitude > 0)
            PinchIn();
        else if (initialMagnitude - finalMagnitude < 0)
            PinchOut();
    }

    private void RightSwipe()
    {
        transform.position += new Vector3(0.5f, 0, 0);
    }
    private void LeftSwipe()
    {
        transform.position += new Vector3(-0.5f, 0, 0);
    }
    private void DownSwipe()
    {
        transform.position += new Vector3(0, 0, 0.5f);
    }
    private void UpSwipe()
    {
        transform.position += new Vector3(0, 0, -0.5f);
    }
    private void PinchIn()
    {
        transform.position += new Vector3(0, 0.5f, 0);
    }
    private void PinchOut()
    {
        transform.position += new Vector3(0, -0.5f, 0);
    }
}
