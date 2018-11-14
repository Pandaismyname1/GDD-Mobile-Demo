using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInput : MonoBehaviour
{

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(3, 3, 3);
    }
    private void OnMouseUp()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
    private void OnMouseDrag()
    {
        transform.localScale += new Vector3(1, 0, 0) * Time.deltaTime;
    }
}
