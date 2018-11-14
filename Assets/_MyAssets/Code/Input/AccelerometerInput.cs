using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerInput : MonoBehaviour
{

    public float Sensivity = 5;
    private Vector3 _additionalAcceleration;

    void Update()
    {
        _additionalAcceleration = Input.acceleration * Sensivity * Time.deltaTime;
        transform.position += new Vector3(_additionalAcceleration.x, 0, _additionalAcceleration.y);
    }
}
