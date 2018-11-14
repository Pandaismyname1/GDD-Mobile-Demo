using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexInput : MonoBehaviour
{
    private Transform _lastHitObject;
    private bool _touchDown;
    private bool _touchHold;

    private void Update()
    {
        if (Input.touchCount == 1 || Input.GetMouseButton(0))
        {
            Debug.Log("TouchDown");
            RaycastHit hit;
            Ray ray;

            if (Input.GetMouseButton(0))
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            else
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("HitObject");
                Transform hitObject = hit.transform;

                if (hitObject != _lastHitObject && _lastHitObject != null)
                    LiftTouchInput();

                if (hitObject.tag == "Interactable")
                {
                    Debug.Log("InteractableHit");
                    _lastHitObject = hitObject;

                    if (_touchDown)
                    {
                        _touchHold = true;
                        _touchDown = false;
                    }

                    if (!_touchHold)
                        _touchDown = true;
                }
            }
        }
        else
        {
            LiftTouchInput();
        }
        if (_touchDown)
        {
            TouchDown();
        }
        if (_touchHold)
        {
            TouchHold();
        }
    }

    private void LiftTouchInput()
    {
        if (_lastHitObject != null)
        {
            _touchDown = false;
            _touchHold = false;
            TouchUp();
            _lastHitObject = null;
        }
    }

    private void TouchDown()
    {
        _lastHitObject.localScale = new Vector3(3, 3, 3);
    }
    private void TouchUp()
    {
        _lastHitObject.localScale = new Vector3(1, 1, 1);
    }
    private void TouchHold()
    {
        _lastHitObject.localScale += new Vector3(1, 0, 0) * Time.deltaTime;
    }
    private void TouchDoubleTap()
    {
        _lastHitObject.localScale += new Vector3(1, 0, 0) * Time.deltaTime;
    }
}
